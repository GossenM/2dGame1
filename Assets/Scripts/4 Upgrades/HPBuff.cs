using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBuff : BaseWeapon
{
    [SerializeField] Julius player;
    
    void Update()
    {
        if (level >= 1 )
        {

            player.maxHp = player.currentMaxHp + (level * 2);
                       
        }
    }
}
