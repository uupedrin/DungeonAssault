using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopUI : UIManager
{
	[SerializeField] TMP_Text coinsText;
	private void Start()
	{
		GameManager.instance.uiManager = this;
		UpdateCoins();
	}
	public void UpdateCoins()
	{
		coinsText.text = $"Coins: {GameManager.instance.coins}";
	}
	public void TryUnlockSkill(SkillButtonInfo info)
	{
		SkillTreeManager.instance.UnlockSkill(info.SkillName, info.SkillType);
	}
}
