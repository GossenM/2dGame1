using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Image foreground;
    void Start()
    {

    }

    
    void Update()
    {
        if (enemy != null)
        {
            transform.position = enemy.transform.position + new Vector3(0, 0.75f, 0);

            float hpRatio = (float)enemy.enemyHP / enemy.enemyMaxHP;
            foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
        }

    }
}

