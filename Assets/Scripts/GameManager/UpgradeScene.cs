using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeScene : MonoBehaviour
{
    [SerializeField] TMP_Text goldCoinsTXT;
    void Update()
    {
        goldCoinsTXT.text = TitleManager.saveData.goldCoins.ToString();
    }
}
