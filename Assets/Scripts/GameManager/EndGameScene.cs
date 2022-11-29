using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameScene : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesKilledDisplay;
    void Start()
    {
        enemiesKilledDisplay.text = TitleManager.saveData.totalEnemiesKilled.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
