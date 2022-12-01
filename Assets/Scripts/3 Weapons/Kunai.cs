using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : BaseWeapon
{
    [SerializeField] float y;


    GameObject player;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    int a = 0;
    int b = 0;
    int c = 0;
    float directionX = 0;
    float directionY1 = 0;
    float directionY2 = 0;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(IceSpikeCoroutine());

    }



    void RotateByDegrees()
    {
        Vector3 rotationToAdd = new Vector3(0, 0, 0.3f);
        //transform.Rotate(rotationToAdd);
    }
    // Update is called once per frame
    void Update()
    {
        //RotateByDegrees();


        if (player != null)
        {
            float scaleX;

            scaleX = player.transform.localScale.x;



            if (a < 1)
            {
                a = 1;

                directionX = -scaleX;

            }

            if (b < 1)
            {
                b = 1;

                directionY1 = -y;

            }

            if (c < 1)
            {
                c = 1;

                directionY2 = y;

            }



            if (directionX == -1)
            {

                transform.position += new Vector3(directionX, directionY1, 0) * Time.deltaTime * 3f;

            }

            if (directionX == 1)
            {

                transform.position += new Vector3(directionX, directionY2, 0) * Time.deltaTime * 3f;

            }

            transform.localScale = new Vector3(-directionX, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(3);
        }
        GolemBoss golemBoss = collision.GetComponent<GolemBoss>();
        if (golemBoss != null)
        {
            golemBoss.Damage(3);
        }


    }

    IEnumerator IceSpikeCoroutine()
    {



        boxCollider.enabled = true;
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(5f);


        boxCollider.enabled = false;
        spriteRenderer.enabled = false;



    }
}
