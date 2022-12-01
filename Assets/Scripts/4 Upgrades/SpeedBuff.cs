using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : BaseWeapon
{
    [SerializeField] Julius julius;
    [SerializeField] Rave rave;

    void Start()
    {
        
    }
    void Update()
    {
        if (level >= 1)
        {

            if (HeroManager.isJulius == true)
            {
                julius.speed = julius.baseSpeed + level;
            }
            else if (HeroManager.isRave == true)
            {
                rave.speed = rave.baseSpeed + level;
            }

        }
    }
}
