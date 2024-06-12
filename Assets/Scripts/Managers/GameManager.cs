using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public PlayerMovement? pMove;
	public ExitPortals exitPortal;
	public UIManager uiManager;
	public PlayerStats pStats;
	public int coins;
	public PlayerCombat pCombat;
	public bool isPaused = false;
	bool gateOpen = false;
	public float countDown;
	float resetedCountDown;
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

	private void Start()
	{
		resetedCountDown = countDown;
	}

	public void Pause()
	{
		isPaused = !isPaused;
		if (isPaused == true)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}

	public void Unpause()
	{
		isPaused = false;
		Time.timeScale = 1f;
	}

	public float PlayerMaxHealth()
	{
		return instance.pCombat.hSystem.MaxHealth();
	}

	public void Reset()
	{
		gateOpen = false;
		countDown = resetedCountDown;
	}

	public void CountDown()
	{
		if (countDown <= 0 && gateOpen == false)
		{
			instance.exitPortal.OpenPortal();
			instance.uiManager.GetComponent<GameUI>().PortalOpen();
			gateOpen = true;
		}
		else countDown -= Time.deltaTime;
	}

	private void Update()
	{
		if(instance.uiManager.SceneName() == "Game")
		{
			CountDown();
			instance.uiManager.GetComponent<GameUI>().TimerUpdate(countDown);
		}
	}
}
