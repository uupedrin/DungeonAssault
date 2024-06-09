using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStat", menuName = "SO/PlayerStat", order = 0)]
public class SOPlayerStats : ScriptableObject {
	public float BaseMoveSpeed;
	public int BaseCoinAmount;
	public float BaseDodgeChance;
}