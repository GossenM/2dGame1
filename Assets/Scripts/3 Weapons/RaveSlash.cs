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
        transform.position += transform.right * 6 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(2);
        }
        RoboDuck roboDuck = collision.GetComponent<RoboDuck>();
        if (roboDuck != null)
        {
            roboDuck.Damage(2);
        }
    }
}
