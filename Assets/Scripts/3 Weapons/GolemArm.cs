using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemArm : MonoBehaviour
{
    //internal GameObject target;

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position += transform.right * 8 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.GetComponent<Julius>();
        Rave player1 = collision.GetComponent<Rave>();
        if (player)
        {
            player.OnDamage(3);
        }
        if (player1)
        {
            player1.OnDamage(3);
        }
    }
}
