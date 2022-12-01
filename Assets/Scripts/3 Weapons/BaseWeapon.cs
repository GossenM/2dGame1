using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    protected int level = 0;
    

   internal void levelUp()
    {
        if(++level == 1)
        {
            gameObject.SetActive(true);
              
        }
    }
    
}
