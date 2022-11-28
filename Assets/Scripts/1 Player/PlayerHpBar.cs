using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] Julius julius;
    [SerializeField] Rave rave;  
    [SerializeField] Image Foreground;


   
    void Update()
    {
        //track player
        //transform.position = player.transform.position + new Vector3 (0,0.75f,0);

        //make hp bar go down as health goes down
        if (HeroManager.isRave == true)
        {
            if (rave != null)
            {
                float hpRatio = (float)rave.playerHP / rave.maxHp;
                Foreground.transform.localScale = new Vector3(hpRatio, 1, 1); 
            } 
        }

        if(HeroManager.isJulius == true)
        {
            if (julius != null)
            {
                float hpRatio = (float)julius.playerHP / julius.maxHp;
                Foreground.transform.localScale = new Vector3(hpRatio, 1, 1); 
            }
        }

    }
}
