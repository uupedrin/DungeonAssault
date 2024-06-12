using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{	
	public static SkillTreeManager instance;
	
	public Action NewSkillUnlocked;
	
	[SerializeField] Skill[] skills;
	Dictionary<string, Skill> GeneralSkillTree; //Skill name / What skill do
	Dictionary<string, Skill> ArcherySkillTree; //Skill name / What skill do
	Dictionary<string, Skill> SwordsmanshipSkillTree; //Skill name / What skill do
	
	void Awake()
	{
		if(instance == null && instance != this)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		CreateSkills();
	}

	void CreateSkills()
	{
		GeneralSkillTree = new();
		ArcherySkillTree = new();
		SwordsmanshipSkillTree = new();
		
		for (int i = 0; i < skills.Length; i++)
		{
			switch (skills[i].skillType)
			{
				case Skill.Type.GENERAL:
				GeneralSkillTree.Add(skills[i].name, skills[i]);
				break;
				
				case Skill.Type.ARCHERY:
				ArcherySkillTree.Add(skills[i].name, skills[i]);
				break;
				
				case Skill.Type.SWORDSMANSHIP:
				SwordsmanshipSkillTree.Add(skills[i].name, skills[i]);
				break;
			}
		}
	}
	
	public int GetSkillPrice(string skillName, Skill.Type skillType)
	{
		switch(skillType)
		{
			case Skill.Type.GENERAL:
			return GeneralSkillTree[skillName].price;
			
			case Skill.Type.ARCHERY:
			return ArcherySkillTree[skillName].price;
			
			case Skill.Type.SWORDSMANSHIP:
			return SwordsmanshipSkillTree[skillName].price;
			
			default:
			return int.MaxValue;
		}
	}
	
	public bool UnlockSkill(string skillName, Skill.Type skillType)
	{
		if(GetSkillPrice(skillName, skillType) <= GameManager.instance.coins)
		{
			bool unlocked;
			switch(skillType)
			{
				case Skill.Type.GENERAL:
				unlocked = GeneralSkillTree[skillName].TryUnlockSkill();
				break;
				
				case Skill.Type.ARCHERY:
				unlocked = ArcherySkillTree[skillName].TryUnlockSkill();
				break;
				
				case Skill.Type.SWORDSMANSHIP:
				unlocked = SwordsmanshipSkillTree[skillName].TryUnlockSkill();
				break;
				
				default:
				unlocked = false;
				break;
			}
			if(unlocked)
			{
				GameManager.instance.pStats.DecreaseCoins(GetSkillPrice(skillName, skillType));
				NewSkillUnlocked?.Invoke();
			}
			return unlocked;
		}
		else return false;
	}
	
	public bool IsUnlocked(string skillName, Skill.Type skillType)
	{
		switch(skillType)
		{
			case Skill.Type.GENERAL:
			return GeneralSkillTree[skillName].unlocked == true;
			
			case Skill.Type.ARCHERY:
			return ArcherySkillTree[skillName].unlocked == true;
			
			case Skill.Type.SWORDSMANSHIP:
			return SwordsmanshipSkillTree[skillName].unlocked == true;
			
			default:
			return false;
		}
	}
}
