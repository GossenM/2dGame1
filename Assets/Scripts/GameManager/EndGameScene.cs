using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameScene : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesKilledDisplay;
    [SerializeField] TMP_Text mermanKilledDisplay;
    [SerializeField] TMP_Text crawlersKilledDisplay;
    [SerializeField] TMP_Text zombiesKilledDisplay;
    [SerializeField] TMP_Text vampiresKilledDisplay;
    [SerializeField] TMP_Text giantKilledDisplay;
    [SerializeField] TMP_Text demonKilledDisplay;

    [SerializeField] TMP_Text goldCoinsTXT;
    [SerializeField] TMP_Text totalCrystals;
    void Start()
    {
        enemiesKilledDisplay.text = TitleManager.saveData.totalEnemiesKilled.ToString();
        mermanKilledDisplay.text = TitleManager.saveData.totalMermanKilled.ToString();
        crawlersKilledDisplay.text = TitleManager.saveData.totalCrawlerKilled.ToString();
        zombiesKilledDisplay.text = TitleManager.saveData.totalZombieKilled.ToString();
        vampiresKilledDisplay.text = TitleManager.saveData.totalVampireKilled.ToString();
        giantKilledDisplay.text = TitleManager.saveData.totalGiantKilled.ToString();
        demonKilledDisplay.text = TitleManager.saveData.totalDemonKilled.ToString();

        goldCoinsTXT.text = TitleManager.saveData.goldCoins.ToString();
        totalCrystals.text = TitleManager.saveData.totalCrystals.ToString();
    }

    void Update()
    {
    }
}
