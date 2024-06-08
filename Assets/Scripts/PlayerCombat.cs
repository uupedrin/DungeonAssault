using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerCombat : MonoBehaviour
{
	PlayerStats stats;
	
	//Skills
	//General
	bool hasRun;
	bool hasDodge;
	bool hasBetterDodge;
	bool hasMoreHealth;
	
	void Start()
	{
		stats = GetComponent<PlayerStats>();
	}
	
	void Update()
	{
		GetSkillInputs();
	}
	
	void SetSkillReferences()
	{
		
	}
	
	void GetSkillInputs()
	{
		if(hasDodge || hasBetterDodge)
		{
			if(Input.GetKeyDown(KeyCode.Space)) //Dodge
			{
				
			}
		}
		
		if(Input.GetKeyDown(KeyCode.R)) //Special
		{
			
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
	
	void SetBool(ref bool boolVariable)
	{
		boolVariable = true;
	}
}
