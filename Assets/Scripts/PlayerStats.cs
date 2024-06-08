using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[SerializeField] SOPlayerStats baseStats;
	public enum Weapons {SWORD,BOW}
	public Action<Weapons> NewEquipedWeapon;
	public Weapons equipedWeapon {get; private set;}
	public int coins {get; private set;}
	public float moveSpeed {get; private set;}
	public float runMultiplyer;
	public bool isRunning = false;
		
	void Awake()
	{
		moveSpeed = baseStats.BaseMoveSpeed;
		coins = baseStats.BaseCoinAmount;
	}
	public void ChangeWeapon(Weapons weaponToEquip)
	{
		equipedWeapon = weaponToEquip;
		NewEquipedWeapon?.Invoke(weaponToEquip);
	}
	
	public void IncreaseCoins(int coinAmount)
	{
		coins += coinAmount;
	}
	
	public void DecreaseCoins(int coinAmount)
	{
		IncreaseCoins(-coinAmount);
	}
}
