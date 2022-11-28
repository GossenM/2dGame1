using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrbs50 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.gameObject.GetComponent<Julius>();
        if (player)
        {
            player.AddBigHP();
            Destroy(gameObject);
        }
    }

}
