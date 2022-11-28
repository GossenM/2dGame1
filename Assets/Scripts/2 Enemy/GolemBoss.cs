using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolemBoss : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject golemArm;

    [SerializeField] GameObject levelCrystal;
    [SerializeField] GameObject Gold;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerCamera playercamera;
    

    [SerializeField] int BossHP;
    [SerializeField] int currentBossHP;

    [SerializeField] bool isBoss;

    [SerializeField] float speed;
    [SerializeField] float baseSpeed = 0.5f;

    public bool isTrackingPlayer = true;
    public bool isInvincible;

    private Animator animator;
    enum GolemState : int
    {
        Idle = 0,
        Walking = 1,
        Attacking = 2,
    }

    GolemState golemState = GolemState.Idle;
    float waitTimer = 2f;


    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentBossHP = BossHP;
        if (isBoss)
        {
            //StartCoroutine(BossCameraCoroutine());
            //BossVignetteFX();
        }
    }



    void Update()
    {
        switch (golemState)
        {
            case GolemState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    golemState = GolemState.Walking;
                }
                break;

            case GolemState.Walking:
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
                animator.SetBool("isWalking", true);
                if (distance < 5f)
                {
                    golemState = GolemState.Attacking;
                }
                break;


            case GolemState.Attacking:
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                golemState = GolemState.Idle;
                waitTimer = 2f;

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
            player.OnDamage();
        }
        if (player1)
        {
            player1.OnDamage();
        }
    }
    



    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
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
            SceneManager.LoadScene("Level2");
            


        }
    }

    internal void SpawnGolemArm()
    {
        var golem = transform.position;
        //giant.y = 0;

        var targetPos = player.transform.position;
        //targetPos.y = 0;

        Vector3 points = (targetPos - golem);

        float angle = Mathf.Atan2(points.y, points.x) * Mathf.Rad2Deg;

        Instantiate(golemArm, transform.position, Quaternion.Euler(0, 0, angle));

    }

    //IEnumerator BossCameraCoroutine()
    //{
    //    Time.timeScale = 0;
    //    Camera.main.GetComponent<PlayerCamera>().target = transform;
    //    yield return new WaitForSecondsRealtime(5f);
    //    Camera.main.GetComponent<PlayerCamera>().target = Julius.transform;
    //    yield return new WaitForSecondsRealtime(1f);
    //    Time.timeScale = 1;

    //}





}
