using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[SerializeField] SOPlayerStats baseStats;
	public enum Weapons {SWORD,BOW}
	public enum DodgeType {None, Normal, Better}
	public Action<Weapons> NewEquipedWeapon;
	public Weapons equipedWeapon {get; private set;}
	public int coins {get; private set;}
	public float moveSpeed {get; private set;}
	public float runMultiplyer;
	public bool isRunning = false;
	public float currentDodgeChance = 0f;
	[SerializeField] float dodgeChanceValue; //max 100
	[SerializeField] float betterDodgeChanceValue; //max 100
		
	void Awake()
	{
		moveSpeed = baseStats.BaseMoveSpeed;
		coins = baseStats.BaseCoinAmount;
		currentDodgeChance = baseStats.BaseDodgeChance;
	}
	private void Start()
	{
		GameManager.instance.pStats = this;
	}
	public void ChangeWeapon(Weapons weaponToEquip)
	{
		equipedWeapon = weaponToEquip;
		NewEquipedWeapon?.Invoke(weaponToEquip);
	}
	
	public void IncreaseCoins(int coinAmount)
	{
		coins += coinAmount;
		if(coins < 0) coins = 0;
	}
	
	public void DecreaseCoins(int coinAmount)
	{
		IncreaseCoins(-coinAmount);
	}
	
	public void SetDodge(DodgeType dodgeType)
	{
		switch (dodgeType)
		{
			case DodgeType.None:
			currentDodgeChance = baseStats.BaseDodgeChance;
			break;
			
			case DodgeType.Normal:
			currentDodgeChance = dodgeChanceValue;
			break;
			
			case DodgeType.Better:
			currentDodgeChance = betterDodgeChanceValue;
			break;
		}
	}
}
