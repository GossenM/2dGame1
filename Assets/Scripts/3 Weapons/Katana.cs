using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapon
{ 
    //colider and appear and reappear
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer.enabled = boxCollider2D.enabled;
        StartCoroutine(katanaCoroutine());
    }


    void Update()
    {

    }
    public IEnumerator katanaCoroutine()
    {
        while (true)
        {
            transform.localScale = Vector3.one * level;
            spriteRenderer.enabled = true ;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(0.5f);

            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(0.5f);
            
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (TitleManager.saveData.katanaDmgIncrease >= 1)
            {
                enemy.Damage(2);
            }
            else
            {
                enemy.Damage(1);
            }
        }
        GolemBoss roboDuck = collision.GetComponent<GolemBoss>();
        if (roboDuck != null)
        {
            if (TitleManager.saveData.katanaDmgIncrease >= 1)
            {
                roboDuck.Damage(2);
            }
            else
            {
                roboDuck.Damage(1);
            }
        }
    } 
   
}
