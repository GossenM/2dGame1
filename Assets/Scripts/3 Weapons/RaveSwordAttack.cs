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

    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(5);
        }
        GolemBoss roboDuck = collision.GetComponent<GolemBoss>();
        if (roboDuck != null)
        {
           roboDuck.Damage(5);
        }
    }

}
