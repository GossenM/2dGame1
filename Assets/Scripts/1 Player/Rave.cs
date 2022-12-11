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
    public float timeBetweenFiring;
    private float currentTimeBetweenFiring = 2;

    public KeyCode slashKey = KeyCode.Space;

    internal Animator animatorRave;
    public bool canSlash = false;
    internal int level;

    protected override void Start()
    {
        animatorRave = GetComponent<Animator>();
        animatorRave.SetBool("IsAttacking", true);
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        SwordSlash();
    }
    public void SwordSlash()
    {
        if (canSlash)
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
                var slash = Instantiate(raveSlashPrefab, transform.position, Quaternion.identity);
                slash.transform.localScale = transform.localScale;
            }
            if (level > 1)
            {
                timeBetweenFiring = currentTimeBetweenFiring - (level / 4);
            }
        }
    }

}
