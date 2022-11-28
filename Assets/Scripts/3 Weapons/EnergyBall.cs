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
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("ball hits enemy");
            enemy.Damage(2);        
        }
        RoboDuck roboDuck = collision.GetComponent<RoboDuck>();
        if(roboDuck != null)
        {
            roboDuck.Damage(2);
        }
        
    }
   

}
    