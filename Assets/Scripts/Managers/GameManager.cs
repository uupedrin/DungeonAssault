using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public UIManager uiManager;
	public PlayerStats pStats;
	private void Awake()
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
	}
}
