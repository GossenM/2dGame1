using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaveSwordAttack : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        //boxCollider2D = GetComponent<BoxCollider2D>();
        //StartCoroutine(SwordCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public IEnumerator SwordCoroutine()
    //{

    //    while (true)
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //        boxCollider2D.enabled = true;
    //        yield return new WaitForSeconds(0.30f);
    //        boxCollider2D.enabled = false;
    //        yield return new WaitForSeconds(0.20f); 
    //    }
     

    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(2);
        }
        GolemBoss roboDuck = collision.GetComponent<GolemBoss>();
        if (roboDuck != null)
        {
           roboDuck.Damage(2);
        }
    }

}
