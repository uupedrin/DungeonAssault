using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIManager
{
    [Header("Panels Management")]
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    [Header("Text Management")]
    public TextMeshProUGUI timerTxt;
    public GameObject portalTxt;

    [Header("Booleans")]
    bool portalActive = false;

    [Header("Images Management")]
    public Image healthBar;

    public void TryUnlockSkill(SkillButtonInfo info)
    {
        SkillTreeManager.instance.UnlockSkill(info.SkillName, info.SkillType);
    }
    public void DeathScreen()
    {
        GameManager.instance.Pause();
        GameManager.instance.Reset();
        defeatPanel.SetActive(true);
    }
    public void VictoryScreen()
    {
        GameManager.instance.Pause();
        GameManager.instance.Reset();
        victoryPanel.SetActive(true);
    }

    public void SkillTreePanel()
    {

    }

    private void TimerSetActive()
    {
        if(timerTxt.gameObject.activeInHierarchy == true)
            timerTxt.gameObject.SetActive(false);
        else 
            timerTxt.gameObject.SetActive(true);
    }

    public void PortalOpen()
    {
        TimerSetActive();
        portalTxt.SetActive(true);
    }

    public void HealthBarUpdate(float value)
    {
        float maxHealth = GameManager.instance.PlayerMaxHealth();
        healthBar.fillAmount = value / maxHealth;
    }

    public void PortalActive()
    {
        portalActive = !portalActive;
        portalTxt.SetActive(portalActive);
    }

    public void TimerUpdate(float timer)
    {
        timer += 1;
        float seconds = Mathf.FloorToInt(timer % 60);
        float minutes = Mathf.FloorToInt(timer / 60);
        timerTxt.text = string.Format("Time Until the Next Portal: {0:00}:{1:00}", minutes, seconds);
    }
}
