using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    [SerializeField] SoulSlicer soulSlicer;
    [SerializeField] GolemBoss golemBoss;
    [SerializeField] Image foreground;
    void Start()
    {

    }


    void Update()
    {
        if (soulSlicer != null)
        {
            transform.position = soulSlicer.transform.position + new Vector3(0, 0.75f, 0);

            float hpRatio = (float)soulSlicer.BossHP / soulSlicer.currentBossHP;
            foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
        }
        else if(golemBoss != null)
        {
            transform.position = soulSlicer.transform.position + new Vector3(0, 0.75f, 0);

            float hpRatio = (float)golemBoss.BossHP / golemBoss.currentBossHP;
            foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
        }

    }
}
