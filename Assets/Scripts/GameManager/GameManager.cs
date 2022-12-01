using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Enemy enemy;

    [SerializeField] GameObject golemBoss;

    [SerializeField] TMP_Text timerText;

    [SerializeField] GameObject healthOrbs;
    [SerializeField] GameObject healthOrbs50;
    [SerializeField] GameObject superP;

    [SerializeField] GameObject julius;
    [SerializeField] GameObject rave;


    
   

     void Start()
    {
        StartCoroutine(SpawnItems());
        StartCoroutine(SpawnGolemBoss(golemBoss, 1));
        if (HeroManager.isRave == true)
        {
            rave.SetActive(true);
           
        }
        if (HeroManager.isJulius == true)
        {
            julius.SetActive(true);
            
        }
        
        
    }
    private void Update()
    {

        int seconds = (int)Time.timeSinceLevelLoad;
        timerText.text = seconds.ToString();
        int minutes = seconds / 60;
        if (minutes >= 1)
        {
            seconds -= minutes * 60;
        }
        if (seconds < 10 && minutes < 10)
        {
            timerText.text = "0" + minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else if (seconds < 10)
        {
            timerText.text = minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else if (minutes < 10)
        {
            timerText.text = "0" + minutes.ToString() + ":" + seconds.ToString();
        }
        
        
         

    }

    IEnumerator SpawnGolemBoss(GameObject bossEnemy, int numberOfBosses,bool isTracking = true)
    {
        while (true)
        {
            for (int i = 0; i < numberOfBosses; i++)
            {
                yield return new WaitForSeconds(50f);
                Vector3 bossSpawn = Random.insideUnitCircle.normalized * 10;
                bossSpawn += player.transform.position;
                GameObject enemyobject = Instantiate(bossEnemy, bossSpawn, Quaternion.identity);
                Enemy enemy = enemyobject.GetComponent<Enemy>();
                enemy.isTrackingPlayer = isTracking;
                
            }
        }
    }
    IEnumerator SpawnItems()
    {
       
        while (true)
        {
            Vector3 randomPosition = Random.insideUnitCircle.normalized * 5;
            yield return new WaitForSeconds(10f);
            randomPosition += player.transform.position;
            Instantiate(healthOrbs, randomPosition, Quaternion.identity); 
            yield return new WaitForSeconds(15f);
            randomPosition += player.transform.position;
            Instantiate(healthOrbs50, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            randomPosition += player.transform.position;
            Instantiate(superP, randomPosition, Quaternion.identity);

        }
    }

    
}

