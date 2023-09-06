using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class GameGUI : MonoBehaviour
{
    public Slider experienceBar;
    public TextMeshProUGUI levelText;


    public void SetPlayerExperience(float percentToLevel, int playerLevel)
    {
        levelText.text = "level: " + playerLevel;
        experienceBar.DOValue(percentToLevel, 0.2f);
    }
}
