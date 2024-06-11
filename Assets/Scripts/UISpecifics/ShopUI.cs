using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopUI : UIManager
{
	[SerializeField] TMP_Text coinsText;
	public void UpdateCoins()
	{
		coinsText.text = GameManager.instance.coins.ToString();
	}
}
