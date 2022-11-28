using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperP : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.gameObject.GetComponent<Julius>();
        if (player)
        {
            //1 find all crystals 
            GameObject[] allcrystals = GameObject.FindGameObjectsWithTag("crystal");
            int currentCrystals = allcrystals.Length;
            //add exp to player = to all crystals consumed
            for (int i = 0; i <= currentCrystals; i++)
            {
                player.AddExp(); 
            }
            //destroy crystals
            Destroy(gameObject);
            KillAll();

        }
    }
    public void KillAll()
    {
        foreach(GameObject cry in GameObject.FindGameObjectsWithTag("crystal"))
        {
            Destroy(cry);
        }
    }
}
