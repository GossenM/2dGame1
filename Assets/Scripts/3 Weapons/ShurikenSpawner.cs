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
    [SerializeField] SimpleObjectPool pool;
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
                yield return new WaitForSeconds(4f);

               
                var shurikenTop = pool.Get();
                shurikenTop.transform.position = transform.position;
                shurikenTop.transform.rotation = Quaternion.Euler(0, 0, 0);
                shurikenTop.SetActive(true);
                
                var shurikenMiddle = pool.Get();
                shurikenMiddle.transform.position = transform.position;
                shurikenMiddle.transform.rotation = Quaternion.Euler(0, 0, 0);
                shurikenMiddle.SetActive(true);
                
                var shurikenBot = pool.Get();
                shurikenBot.transform.position = transform.position;
                shurikenBot.transform.rotation = Quaternion.Euler(0, 0, 0);
                shurikenBot.SetActive(true);
                //Instantiate(shurikenTop, transform.position, Quaternion.Euler(0, 0, 0));
                //Instantiate(shurikenMiddle, transform.position, Quaternion.Euler(0, 0, 0));
                //Instantiate(shurikenBottom, transform.position, Quaternion.Euler(0, 0, 0));

            }

        }



    }
   
}
