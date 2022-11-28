using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.gameObject.GetComponent<Julius>();
        if (player)
        {
            TitleManager.saveData.goldCoins++;
            Destroy(gameObject);
        }
    }

}
