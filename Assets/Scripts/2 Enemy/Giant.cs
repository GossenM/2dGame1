using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Giant : Enemy
{
    internal Giant giant;
    internal Enemy enemy;

    [SerializeField] GameObject knifePrefab;
    //[SerializeField] GameObject CrystalPrefab;
    //[SerializeField] GameObject Gold;
    //[SerializeField] SpriteRenderer spriteRenderer;


    enum GiantState : int
    {
        Idle = 0,
        Walking = 1,
        Attacking = 2,
    }
    
    GiantState giantState = GiantState.Idle;
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
        switch (giantState)
        {
            case GiantState.Idle:
                waitTimer -= Time.deltaTime;
                if(waitTimer <= 0)
                {
                    giantState = GiantState.Walking;
                }
                break;

            case GiantState.Walking:
                base.Update();
                float distance = Vector3.Distance(transform.position, Julius.transform.position);
                animator.SetBool("IsWalking", true);
                if(distance < 5f)
                {    
                    giantState = GiantState.Attacking;
                }
                break;

            case GiantState.Attacking:
                animator.SetBool("IsWalking", false);
                animator.SetTrigger("Attack");
                giantState = GiantState.Idle;
                waitTimer = 2f;
                
                break;

            default:
                break;
        }
    }

    
    public override void Damage(int damage)
    {
        giantState = GiantState.Idle;
        waitTimer = 2f;
        base.Damage(damage);
    }

    internal void SpawnKnife()
    {
        var giant = transform.position;
        //giant.y = 0;

        var targetPos = Julius.transform.position;
        //targetPos.y = 0;

        Vector3 points = (targetPos - giant);

        float angle = Mathf.Atan2(points.y,points.x) * Mathf.Rad2Deg;

        Instantiate(knifePrefab, transform.position, Quaternion.Euler(0,0,angle));
        
    }
}
