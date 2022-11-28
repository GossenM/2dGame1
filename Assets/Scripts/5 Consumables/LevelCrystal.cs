using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCrystal : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.gameObject.GetComponent<Julius>();
        if (player)
        {
            player.AddBossLevel();
            Destroy(gameObject);
        }
    }
}
