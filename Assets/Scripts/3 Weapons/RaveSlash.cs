using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaveSlash : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.position += transform.right * 6 * Time.deltaTime * transform.localScale.x * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(2);
        }
        GolemBoss golemBoss = collision.GetComponent<GolemBoss>();
        if (golemBoss != null)
        {
            golemBoss.Damage(2);
        }
        SoulSlicer soulSlicer = collision.GetComponent<SoulSlicer>();
        if (soulSlicer != null)
        {
            soulSlicer.Damage(2);
        }


    }
}
