using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerCombat : MonoBehaviour
{
	PlayerStats stats;
	PlayerStats.DodgeType currentDodge;
	//Skills
	//General
	bool hasRun;
	bool hasSpin;
	bool canUseSpin = true;
	[SerializeField] float spinCooldown;
	bool hasPrecision;
	bool canUsePrecision = true;
	[SerializeField] float precisionCooldown;
	bool hasSwordBeam;
	bool canUseBeam = true;
	[SerializeField] float beamCooldown;
	
	void Start()
	{
		stats = GetComponent<PlayerStats>();
		SkillTreeManager.instance.NewSkillUnlocked += VerifyUnlocks;
	}
	
	private void OnDestroy()
	{
		SkillTreeManager.instance.NewSkillUnlocked -= VerifyUnlocks;
	}
	
	void Update()
	{
		GetSkillInputs();
	}
	
	public void VerifyUnlocks()
	{
		hasRun = SkillTreeManager.instance.IsUnlocked("Run", Skill.Type.GENERAL);
		
		currentDodge = PlayerStats.DodgeType.None;
		if(SkillTreeManager.instance.IsUnlocked("Dodge", Skill.Type.GENERAL))
		{
			currentDodge = PlayerStats.DodgeType.Normal;
		}
		if(SkillTreeManager.instance.IsUnlocked("BetterDodge", Skill.Type.GENERAL))
		{
			currentDodge = PlayerStats.DodgeType.Better;
		}
		stats.SetDodge(currentDodge);
		
		
	}
	void SwordBeam()
	{
		if(!canUseBeam) return;
		//Beam logic
	}
	
	void GetSkillInputs()
	{		
		if(Input.GetKeyDown(KeyCode.R)) //Special
		{
			switch (stats.equipedWeapon)
			{
				case PlayerStats.Weapons.SWORD:
				
				break;
				case PlayerStats.Weapons.BOW:
				break; 
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Q)) //Special 2
		{
			switch (stats.equipedWeapon)
			{
				case PlayerStats.Weapons.SWORD:
				
				break;
				case PlayerStats.Weapons.BOW:
				
				break; 	
			}
		}
		
		if(hasRun)
		{
			if(Input.GetKey(KeyCode.LeftShift)) // Run
			{
				stats.isRunning = true;
			}
			else
			{
				stats.isRunning = false;
			}
		}
	}
	
	private void OnCollisionEnter(Collision other)
	{
		//Harmfull Collisions
		float dodgeOdds = Random.Range(0,100);
		if(stats.currentDodgeChance > dodgeOdds) //Don't dodge
		{
			//Take hit
		}
	}
}
