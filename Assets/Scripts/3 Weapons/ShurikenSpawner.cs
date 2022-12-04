using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ShurikenSpawner : BaseWeapon
{
    [SerializeField] GameObject shurikenTop;
    [SerializeField] GameObject shurikenMiddle;
    [SerializeField] GameObject shurikenBottom;
    [SerializeField] GameObject player;
    void Start()
    {
        StartCoroutine(SpawnShurikenCoroutine());

    }

    IEnumerator SpawnShurikenCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                yield return new WaitForSeconds(2f);


                Instantiate(shurikenTop, transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(shurikenMiddle, transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(shurikenBottom, transform.position, Quaternion.Euler(0, 0, 0));

            }

        }



    }
   
}
