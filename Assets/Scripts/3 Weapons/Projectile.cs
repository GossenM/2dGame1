using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseWeapon
{
    [SerializeField] GameObject scythe;
    [SerializeField] GameObject Energyball;

    void Start()
    {
        StartCoroutine(SpawnScytheCoroutine());
        Instantiate(Energyball, transform.position, Quaternion.Euler(0, 0, 0));
    }

    IEnumerator SpawnScytheCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            for (int i = 0; i < level; i++)
            {
                float angle = Random.Range(0, 360);
                Instantiate(scythe, transform.position, Quaternion.Euler(0, 0, angle)); 
            }
        }

    }

  
    
    
}
