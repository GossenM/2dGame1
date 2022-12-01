using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBuff : BaseWeapon
{

    [SerializeField] Julius julius;
    [SerializeField] Rave rave;

    void Start()
    {
        
    }
    void Update()
    {
        if (level >= 1 )
        {

            if(HeroManager.isJulius == true)
            {
                julius.maxHp = julius.currentMaxHp + (level * 2); 
            }
            else if(HeroManager.isRave == true)
            {
                rave.maxHp = rave.currentMaxHp + (level * 2); 
            }
                       
        }
    }
}
