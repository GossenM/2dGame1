using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnergyBall : BaseWeapon
{
    internal GameObject target;
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

    }


    public float initialRotation = 10;

    public float baseSpeed = 10;

    public float CircleRadius = 2;

    public float ElevationOffset = 0;

    private Vector3 positionOffset;
    private float angle;
    
    public void Update()
    {
       if(level > 1)
        {
            int speed = 1 + level;
            int size = level;
            initialRotation = baseSpeed + level;
            transform.localScale = Vector3.one * size;
        }


    }
    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos(angle) * CircleRadius,
            Mathf.Sin(angle) * CircleRadius,
            ElevationOffset
        );
        transform.position = target.transform.position + positionOffset;
        angle += Time.deltaTime * initialRotation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(2);
        }
        GolemBoss golemBoss = collision.GetComponent<GolemBoss>();
        if (golemBoss != null)
        {
            golemBoss.Damage(2);
        }
        SoulSlicer soulSlicer = collision.GetComponent<SoulSlicer>();
        if(soulSlicer != null)
        {
            soulSlicer.Damage(2);
        }


    }
   

}
    