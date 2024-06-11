using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] GameObject[] enemies;
	[SerializeField] Transform[] position;
	[SerializeField] float timer;
	float wTime;
	int randomE, randomP;
	
	 
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		Timer();
	}
	
	public void Timer()
	{
			wTime+= Time.deltaTime;
			if(wTime >= timer)
			{
				Spawn();
				wTime = 0;
			}
	}
	
	void Spawn()
	{
		randomE = Random.Range(0, enemies.Length);
		randomP = Random.Range(0, position.Length);
		GameObject enemy = Instantiate(enemies[randomE], position[randomP]);
	}
}
