using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : BaseWeapon
{
    [SerializeField] Julius player;

    void Update()
    {
        if (level <= 3)
        { 

            player.speed = player.baseSpeed + level;
            
        }
    }
}
