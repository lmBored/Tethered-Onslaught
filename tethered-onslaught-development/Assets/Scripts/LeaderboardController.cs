using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    public Text longestSurvivalTimeText;
    public Text highestComboChainsText;

    private float longestSurvivalTime = 0f;
    private int highestComboChains = 0;

    void Start()
    {
        UpdateLeaderboard();
    }

    public void UpdateSurvivalTime(float survivalTime)
    {
        if (survivalTime > longestSurvivalTime)
        {
            longestSurvivalTime = survivalTime;
            UpdateLeaderboard();
        }
    }

    public void UpdateComboChains(int comboChains)
    {
        if (comboChains > highestComboChains)
        {
            highestComboChains = comboChains;
            UpdateLeaderboard();
        }
    }

    void UpdateLeaderboard()
    {
        longestSurvivalTimeText.text = "Longest Survival Time: " + longestSurvivalTime.ToString("F2") + "s";
        highestComboChainsText.text = "Highest Combo Chains: " + highestComboChains;
    }
}
