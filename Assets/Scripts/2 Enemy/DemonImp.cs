using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonImp : Enemy
{
    
    internal Enemy enemy;

    //[SerializeField] GameObject CrystalPrefab;
    //[SerializeField] GameObject Gold;
    //[SerializeField] SpriteRenderer spriteRenderer;


    enum DemonState : int
    {
        Idle = 0,
        Walking = 1,
        Attacking = 2,
    }

    DemonState demonState = DemonState.Idle;
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
        switch (demonState)
        {
            case DemonState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    demonState = DemonState.Walking;
                }
                break;

            case DemonState.Walking:
                base.Update();
                float distance = Vector3.Distance(transform.position, Julius.transform.position);
                animator.SetBool("IsWalking", true);
                if (distance < 1f)
                {
                    demonState = DemonState.Attacking;
                }
                break;

            case DemonState.Attacking:
                animator.SetBool("IsWalking", false);
                animator.SetTrigger("Attack");
                demonState = DemonState.Idle;
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
