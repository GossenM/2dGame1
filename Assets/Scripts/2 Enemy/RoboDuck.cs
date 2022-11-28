using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoboDuck : MonoBehaviour
{

    [SerializeField] GameObject Julius;

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


    void Start()
    {
        Julius = GameObject.FindGameObjectWithTag("Player");
        currentBossHP = BossHP;
        if (isBoss)
        {
            //StartCoroutine(BossCameraCoroutine());
            //BossVignetteFX();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Julius player = collision.GetComponent<Julius>();
        if (player)
        {
            if (player.OnDamage())
            {
                Damage(1);
            }
        }
    }


    void Update()
    {
        Vector3 destination = Julius.transform.position;
        Vector3 source = transform.position;
        Vector3 direction = destination - source;

        if (!isTrackingPlayer)
        {
            direction = new Vector3(1, 0, 0);
        }
        direction.Normalize();

        transform.position += direction * Time.deltaTime * speed;

        transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);

        if (currentBossHP <= BossHP / 2)
        {
            speed = baseSpeed * 3;
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

    //IEnumerator BossCameraCoroutine()
    //{
    //    Time.timeScale = 0;
    //    Camera.main.GetComponent<PlayerCamera>().target = transform;
    //    yield return new WaitForSecondsRealtime(5f);
    //    Camera.main.GetComponent<PlayerCamera>().target = Julius.transform;
    //    yield return new WaitForSecondsRealtime(1f);
    //    Time.timeScale = 1;

    //}
    public void BossVignetteFX()
    {
        //playercamera.vignette.color.Override(Color.black);
        //playercamera.vignette.intensity.Override(0.7f);

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






}
