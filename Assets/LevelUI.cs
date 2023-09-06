using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Image lockImg;
    public int levelReward;
    public TextMeshProUGUI rewardText;

    private void Start()
    {
        rewardText.text ="Number of Enemies: " + levelReward.ToString();   
    }
    public void SelectLevel(int level)
    {
       MainMenuUI.Instance.SelectLevel(level);
    }
}
