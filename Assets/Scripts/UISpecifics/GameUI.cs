using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : UIManager
{
    public void TryUnlockSkill(SkillButtonInfo info)
    {
        SkillTreeManager.instance.UnlockSkill(info.SkillName, info.SkillType);
    }
}
