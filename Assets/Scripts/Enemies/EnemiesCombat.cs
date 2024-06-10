using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(EnemiesMovement))]
[RequireComponent(typeof(Rigidbody))]

public class EnemiesCombat : MonoBehaviour
{
    public HealthSystem hSystem;
    [SerializeField] ScriptableObject eStats;
    public EnemiesMovement eMovement;
    [SerializeField] float fireRatioArcher;
    bool canFire = true;
    [SerializeField] Transform bow;
    [SerializeField] GameObject eBullet;

    void Start()
    {
        eMovement = eMovement.GetComponent<EnemiesMovement>();
        GetComponent<HealthSystem>().OnDeath += OnEnemieDeath;
        hSystem = GetComponent<HealthSystem>();
    }

    void OnEnemieDeath()
    {
        GetComponent<HealthSystem>().OnDeath -= OnEnemieDeath;
        GameManager.instance.pStats.IncreaseCoins(20);
        Destroy(gameObject);
    }

    void CombatStyle()
    {
        switch (eMovement.eBehaviour)
        {
            case EnemiesMovement.Behaviour.Archer:
                ArcherShoot();
                break;

            case EnemiesMovement.Behaviour.Tank:

                break;

            case EnemiesMovement.Behaviour.Rogue:

                break;

            default:
                Debug.LogError("Error: Object Not Seted in a Behaviour");
                break;
        }
    }

    private void Update()
    {
       CombatStyle();
    }

    void ArcherShoot()
    {
        if(canFire == true)
            StartCoroutine(nameof(Shoot));
    }

    IEnumerator Shoot()
    {
        canFire = false;
        Instantiate(eBullet, bow.position, bow.rotation);
        yield return new WaitForSeconds(fireRatioArcher);
        canFire = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "PBullet":
                hSystem.DecreaseHealth(1);
                break;

            case "Player":
                hSystem.DecreaseHealth(99999);
                break;
        }
    }

}
