using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Rave : Julius
{

    public GameObject raveSlashPrefab;

    public bool canFire;
    private float timer;
    public float timeBetweenFiring = 2;

    public KeyCode slashKey = KeyCode.Space;

    internal Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsAttacking", true);
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    public void SwordSlash()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetKeyDown(slashKey) && canFire)
        {
            canFire = false;
            Instantiate(raveSlashPrefab, transform.position, Quaternion.identity);
        }
    }

}
