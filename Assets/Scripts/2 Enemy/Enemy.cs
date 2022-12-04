using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] internal float speed = 1f;
    [SerializeField] protected GameObject Julius;
    [SerializeField] protected GameObject Rave;
    [SerializeField] GameObject CrystalPrefab;
    [SerializeField] GameObject Gold;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] public int enemyHP;
    [SerializeField] public int enemyMaxHP;
    //public int currentEnemyHP;
    public bool isTrackingPlayer = true;
    public bool isInvincible;

    GameObject[] merman;


    protected virtual void Start()
    {
        Julius = GameObject.FindGameObjectWithTag("Player");
        Rave = GameObject.FindGameObjectWithTag("Player");
        enemyHP = enemyMaxHP;
    }


    protected virtual void Update()
    {
        Vector3 destination = Julius.transform.position;
        Vector3 source = transform.position;
        Vector3 direction = destination - source;

        if (!isTrackingPlayer)
        {
            direction = new Vector3(1,0,0);
        }
        direction.Normalize();

        transform.position += direction * Time.deltaTime * speed;
        
        transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1,1);

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.GetComponent<Julius>();
        Rave player1 = collision.GetComponent<Rave>();
        if (player)
        {
            player.OnDamage(1);
        }
        if (player1)
        {
            player1.OnDamage(1);
        }
    }

   public virtual IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
        isInvincible = false;

    }
        
    

    public virtual void Damage(int damage)
    {

        
        enemyHP -= damage;
        StartCoroutine(InvincibilityCoroutine());
        if (enemyHP <= 0)
        {
            int randNum = Random.Range(0,100);
            if(randNum > 50)
            {
                Instantiate(Gold, transform.position, Quaternion.identity);
                Instantiate(CrystalPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                KilledEnemyStats();
            }
            else
            {
                Instantiate(CrystalPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                KilledEnemyStats();
            }  
        }
    }
    public void KilledEnemyStats()
    {
        TitleManager.saveData.totalEnemiesKilled ++;
        if (gameObject.tag == "Merman")
        {
            TitleManager.saveData.totalMermanKilled ++;
        }
        else if (gameObject.tag == "Crawler")
        {
            TitleManager.saveData.totalCrawlerKilled ++;
        }
        else if (gameObject.tag == "Zombie")
        {
            TitleManager.saveData.totalZombieKilled ++;
        }
        else if (gameObject.tag == "Vampire")
        {
            TitleManager.saveData.totalVampireKilled ++;
        }
        else if (gameObject.tag == "Giant")
        {
            TitleManager.saveData.totalGiantKilled ++;
        }
        else if (gameObject.tag == "Demon")
        {
            TitleManager.saveData.totalDemonKilled++;
        }
    }

    public void Lol()
    {
        TitleManager.saveData.totalEnemiesKilled = TitleManager.saveData.totalEnemiesKilled + 1;
        GameObject merman = GameObject.FindGameObjectWithTag("Merman");
        GameObject crawler = GameObject.FindGameObjectWithTag("Crawler");
        GameObject zombie = GameObject.FindGameObjectWithTag("Zombie");
        GameObject vampire = GameObject.FindGameObjectWithTag("Vampire");
        GameObject giant = GameObject.FindGameObjectWithTag("Giant");
        if (merman == null)
        {
            TitleManager.saveData.totalMermanKilled = TitleManager.saveData.totalMermanKilled + 1;
        }
        if (crawler == null)
        {
            TitleManager.saveData.totalCrawlerKilled = TitleManager.saveData.totalCrawlerKilled + 1;
        }
        else if (zombie == null)
        {
            TitleManager.saveData.totalZombieKilled = TitleManager.saveData.totalZombieKilled + 1;
        }
        else if (vampire == null)
        {
            TitleManager.saveData.totalVampireKilled = TitleManager.saveData.totalVampireKilled + 1;
        }
        else if (giant == null)
        {
            TitleManager.saveData.totalGiantKilled = TitleManager.saveData.totalGiantKilled + 1;
        }
    }

    


    

}
