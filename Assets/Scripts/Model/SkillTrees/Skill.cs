using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewSkill", menuName = "SO/Skill", order = 0)]
public class Skill : ScriptableObject {
	public enum Type {GENERAL, ARCHERY, SWORDSMANSHIP}
	public Type skillType;
	public Action skillEnabled;
	public Skill[] requirements;
	public int price;
	public bool unlocked = false;
	
	public bool TryUnlockSkill()
	{
		bool canUnlock = true;
		for (int i = 0; i < requirements.Length; i++)
		{
			if(!requirements[i].unlocked)
			{
				canUnlock = false;
			}
		}
		
		if(canUnlock)
		{
			unlocked = true;
			skillEnabled?.Invoke();
		}
		return unlocked;
	}
}
