using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Enemy
{
    enum CrawlerState : int
    {
        Idle = 0,
        Walking = 1,
        Attacking = 2,
    }

    CrawlerState crawlerState = CrawlerState.Idle;
    float waitTimer = 2f;

    private Animator animator;


    protected override void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        base.Start();
    }

    protected override void Update()
    {
        switch (crawlerState)
        {
            case CrawlerState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    crawlerState = CrawlerState.Walking;
                }
                break;

            case CrawlerState.Walking:
                base.Update();
                float distance = Vector3.Distance(transform.position, Julius.transform.position);
                animator.SetBool("IsWalking", true);
                if (distance < 1f)
                {
                    crawlerState = CrawlerState.Attacking;
                }
                break;

            case CrawlerState.Attacking:
                animator.SetBool("IsWalking", false);
                animator.SetTrigger("Attack");
                crawlerState = CrawlerState.Idle;
                waitTimer = 1f;

                break;

            default:
                break;
        }
    }


    public override void Damage(int damage)
    {
        base.Damage(damage);
    }
}
