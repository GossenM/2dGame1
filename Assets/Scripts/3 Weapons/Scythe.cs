using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : BaseWeapon
{
    private void Update()
    {
        transform.position += transform.up * 6 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
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
