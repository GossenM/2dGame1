using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] Julius julius;
    [SerializeField] Rave rave;
    [SerializeField] Image Foreground;



    void Update()
    {
        
        if (HeroManager.isRave == true)
        {
            if (rave != null)
            {
                float expRatio = (float)rave.currentExp / rave.expToLevel;
                Foreground.transform.localScale = new Vector3(expRatio, 1, 1); 
            }
        }

        if (HeroManager.isJulius == true)
        {
            if (julius != null)
            {
                float expRatio = (float)julius.currentExp / julius.expToLevel;
                Foreground.transform.localScale = new Vector3(expRatio, 1, 1); 
            }
        }

    }
}
