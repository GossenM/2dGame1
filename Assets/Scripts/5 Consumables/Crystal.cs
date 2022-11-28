using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.gameObject.GetComponent<Julius>();
        if (player)
        {
            player.AddExp();
            Destroy(gameObject);
        }
    }
}
