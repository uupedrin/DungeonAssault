using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(HealthSystem))]
public class PlayerCombat : MonoBehaviour
{
	[Header("Stats and Skills")]
	public HealthSystem hSystem;
	PlayerStats stats;
	PlayerStats.DodgeType currentDodge;

	[Header("Weapons and Bullet")]
	bool hasRun;
	public GameObject bullet;
	[SerializeField] float fireRatio;
	bool canFire = true;
	[SerializeField] Transform[] bulletSpawnpoints;
	[SerializeField] Transform orientation;

	
	void Start()
	{
		GameManager.instance.pCombat = this;
		stats = GetComponent<PlayerStats>();
		SkillTreeManager.instance.NewSkillUnlocked += VerifyUnlocks;
		GetComponent<HealthSystem>().OnDeath += OnPlayerDeath;
		hSystem = GetComponent<HealthSystem>();
	}
	
	private void OnDestroy()
	{
		SkillTreeManager.instance.NewSkillUnlocked -= VerifyUnlocks;
        GetComponent<HealthSystem>().OnDeath = OnPlayerDeath;
    }

	void Update()
	{
		GetSkillInputs();
		if (Input.GetMouseButton(0) && canFire == true)
		{
			StartCoroutine(nameof(ShootCoroutine));
		}

	}

	IEnumerator ShootCoroutine()
	{
		canFire = false;
		Instantiate(bullet, bulletSpawnpoints[0].transform.position, orientation.rotation);
		yield return new WaitForSeconds(fireRatio);
		canFire = true;
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

	void OnPlayerDeath()
	{
		GameManager.instance.uiManager.GetComponent<GameUI>().DeathScreen();
	}
	
	private void OnCollisionEnter(Collision other)
	{
		//Harmfull Collisions
		float dodgeOdds = Random.Range(0,100);
		if(stats.currentDodgeChance < dodgeOdds) //Don't dodge
		{
			//Take hit
			switch (other.gameObject.tag)
			{
				case "Enemy":
					Debug.Log("entrando na tag Enemy");
					hSystem.DecreaseHealth(1);
					GameManager.instance.uiManager.GetComponent<GameUI>().HealthBarUpdate(hSystem.HealthValue());
					Debug.Log("Está saindo do decrese health");
					break;

				case "EBullet":
                    hSystem.DecreaseHealth(1);
                    GameManager.instance.uiManager.GetComponent<GameUI>().HealthBarUpdate(hSystem.HealthValue());
                    Destroy(other.gameObject);
                    break;

				case "Portal":
					GameManager.instance.uiManager.GetComponent<GameUI>().VictoryScreen();
					break;
			}
		}
	}
}
