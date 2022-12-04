using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerSwing : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.GetComponent<Julius>();
        Rave player1 = collision.GetComponent<Rave>();
        if (player)
        {
            player.OnDamage(2);
        }
        if (player1)
        {
            player1.OnDamage(2);
        }
    }

}
