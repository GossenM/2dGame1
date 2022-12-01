using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class KunaiSpawner : BaseWeapon
{
    [SerializeField] GameObject iceSpike1;
    [SerializeField] GameObject iceSpike2;
    [SerializeField] GameObject iceSpike3;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDaggerCoroutine());


    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator SpawnDaggerCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                yield return new WaitForSeconds(2f);


                Instantiate(iceSpike1, transform.position, Quaternion.identity);
                Instantiate(iceSpike2, transform.position, Quaternion.identity);
                Instantiate(iceSpike3, transform.position, Quaternion.identity);

            }

        }



    }
   
}
