using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;

public class Julius : MonoBehaviour
{
   
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] public GameObject levelUpMenu;
    [SerializeField] public GameObject RaveLevelUpMenu;

    [SerializeField] public BaseWeapon[] weapons;

    [SerializeField] TMP_Text levelDisplay;
    [SerializeField] TMP_Text goldDisplay;
    [SerializeField] public PlayerCamera playerCamera;

    Animator animator;
    Material material;
    public AudioSource audioSource;
    

    public float speed;
    public float baseSpeed;

    public float playerHP;
    public float maxHp;
    public float currentMaxHp;


    public float healthOrbs;
    public float healthOrbs50;
    public bool isInvincible;

    internal int currentExp;
    internal int expToLevel = 5;
    internal int currentLevel;
   
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Hp set up 
        maxHp =maxHp + TitleManager.saveData.healthIncrease;
        playerHP = maxHp;
        //shader materiel set up
        material = spriteRenderer.material;

        

    }


    protected virtual void Update()
    {
       
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(inputX, inputY, 0) * speed * Time.deltaTime;
        //shift f1 end to select line then ctrl + k s
        if (inputX != 0)
        {
            transform.localScale = new Vector3(inputX > 0 ? -1 :  1, 1, 1);
        }
        bool isRunning = (inputX != 0 || inputY != 0);
        if (HeroManager.isJulius == true)
        {
            animator.SetBool("isRunning", isRunning); 
        }

        levelDisplay.text = currentLevel.ToString();
        goldDisplay.text = TitleManager.saveData.goldCoins.ToString();
    }

    internal void AddExp()
    {
        currentExp += 1;
        if (currentExp == expToLevel)
        {
            currentExp = 0;
            expToLevel += 7;
            currentLevel++;

            
            Time.timeScale = 0;
            if (HeroManager.isJulius == true)
            {
                levelUpMenu.SetActive(true);
            }
            else if (HeroManager.isRave == true)
            {
                RaveLevelUpMenu.SetActive(true);
            }
            audioSource.Play();
            playerCamera.depthOfField.focalLength.Override(150);
            

        }
    }
    internal void AddBossLevel()
    {
        currentLevel += 2;
        int randomIndex = Random.Range(0, weapons.Length);
        weapons[randomIndex].levelUp();
    }
    public float GetHpRatio()
    {
        return (float)playerHP / maxHp;
    }
    internal void AddSmallHP()
    {
        if (playerHP <= maxHp - 2)
        {
            playerHP = playerHP + healthOrbs;
        }
    }
    internal void AddBigHP()
    {
        if (playerHP <= maxHp - 5)
        {
            playerHP = playerHP + healthOrbs50;
        }
    }
    public bool OnDamage(int damage)
    {

        if (!isInvincible)
        {
            playerHP -= damage;
            StartCoroutine(InvincibilityCoroutine());
            isInvincible = true;
            playerCamera.StartShake(0.05f, 0.2f);


            if (playerHP <= 0)
            {
                
                StartCoroutine(DeathCoroutine());
                
            }
            return true;
        }
        return false;

    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        //spriteRenderer.color = Color.red;
        material.SetFloat("_Flash", 0.33f);
        yield return new WaitForSeconds(2f);
        //spriteRenderer.color = Color.white;
        material.SetFloat("_Flash", 0);
        isInvincible = false;
    }
    IEnumerator DeathCoroutine()
    {
        Time.timeScale = 0;
        playerCamera.colorAdjustments.saturation.Override(-100);
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
        Time.timeScale = 1;
        SceneManager.LoadScene("EndGame");
    }

}