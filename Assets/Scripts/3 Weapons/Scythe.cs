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
        SoulSlicer roboDuck = collision.GetComponent<SoulSlicer>();
        if (roboDuck != null)
        {
            roboDuck.Damage(2);
        }
       

    }
}
