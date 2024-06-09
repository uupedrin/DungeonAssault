using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	public Action OnDeath;
	
	[SerializeField] float maxHealth;
	float currentHealth;
	
	private void Awake()
	{
		currentHealth = maxHealth;
	}
	
	public void IncreaseHealth(float value)
	{
		currentHealth += value;
		if(currentHealth <= 0) OnDeath?.Invoke();
		if(currentHealth > maxHealth) currentHealth = maxHealth;
	}
	
	public void DecreaseHealth(float value)
	{
		IncreaseHealth(-value);
	}
	
	public void SetNewMaxHealth(float maxHealth)
	{
		this.maxHealth = maxHealth;
	}
}
