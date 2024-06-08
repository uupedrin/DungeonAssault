using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
	public static SkillTreeManager instance;
	
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
	
	public void UnlockSkill(string skillName, Skill.Type skillType)
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
	}
	
	public Action SetReferenceToSkill(string skillName, Skill.Type skillType)
	{
		Skill skill = null;
		switch(skillType)
		{
			case Skill.Type.GENERAL:
			skill = GeneralSkillTree[skillName];
			break;
			
			case Skill.Type.ARCHERY:
			skill = ArcherySkillTree[skillName];
			break;
			
			case Skill.Type.SWORDSMANSHIP:
			skill = SwordsmanshipSkillTree[skillName];
			break;
		}
		
		if(skill != null)
		{
			return skill.skillEnabled;
		}
		else 
		{
			Debug.LogError("Invalid Skill Name!");
			throw new Exception("Invalid Skill Name!");
		}
	}
}
