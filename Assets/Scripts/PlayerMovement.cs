using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerCombat))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Transform orientation;
	float moveSpeed;
	Rigidbody rb;
	PlayerCombat pCombat;
	PlayerStats pStats;
	float horizontal;
	float vertical;
	
	void Start()
	{
		GameManager.instance.pMove = this;
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		pStats = GetComponent<PlayerStats>();
		pCombat = GetComponent<PlayerCombat>();
	}

	void Update()
	{
		GetInputs();
	}
	
	void FixedUpdate()
	{
		MovePlayer();
	}
	
	void GetInputs()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
	}
	
	void MovePlayer()
	{
		float speed = pStats.isRunning ? pStats.moveSpeed * pStats.runMultiplyer : pStats.moveSpeed;
		Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
		rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
	}
}
