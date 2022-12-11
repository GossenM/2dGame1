using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoulSlicer : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] GameObject levelCrystal;
    [SerializeField] GameObject Gold;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerCamera playercamera;


    [SerializeField] internal int BossHP;
    [SerializeField] internal int currentBossHP;

    [SerializeField] bool isBoss;

    [SerializeField] float speed;
    [SerializeField] float baseSpeed = 0.5f;

    public bool isTrackingPlayer = true;
    public bool isInvincible;

    private Animator animator;
    Material material;
    enum SoulState : int
    {
        Idle = 0,
        Running = 1,
        Attacking = 2,
    }

    SoulState soulState = SoulState.Idle;
    float waitTimer = 2f;


    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentBossHP = BossHP;
        material = spriteRenderer.material;
    }



    void Update()
    {
        switch (soulState)
        {
            case SoulState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    soulState = SoulState.Running;
                }
                break;

            case SoulState.Running:
                Vector3 destination = player.transform.position;
                Vector3 source = transform.position;
                Vector3 direction = destination - source;

                if (!isTrackingPlayer)
                {
                    direction = new Vector3(1, 0, 0);
                }
                direction.Normalize();

                transform.position += direction * Time.deltaTime * speed;

                transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);

                if (currentBossHP <= BossHP / 2)
                {
                    speed = baseSpeed * 3;
                }
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("IsRunning", true);
                if (distance < 1.5f)
                {
                    soulState = SoulState.Attacking;
                }
                break;


            case SoulState.Attacking:
                animator.SetBool("IsRunning", false);
                animator.SetTrigger("Attack");
                soulState = SoulState.Idle;
                waitTimer = 3f;

                break;

            default:
                break;
        }
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




    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        material.SetFloat("_Flash", 0.33f);
        //spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        material.SetFloat("_Flash", 0);
        //spriteRenderer.color = Color.white;
        isInvincible = false;

    }


    internal void Damage(int damage)
    {
        if (isInvincible)
        {
            return;
        }
        currentBossHP -= damage;
        StartCoroutine(InvincibilityCoroutine());
        if (currentBossHP <= 0)
        {

            Instantiate(levelCrystal, transform.position, Quaternion.identity);
            Instantiate(Gold, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene("EndGame");

        }
    }
}
