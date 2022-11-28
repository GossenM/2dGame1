using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static WaveSpawner;

public class HeroManager : MonoBehaviour
{
    public static bool isJulius = false;
    public static bool isRave = false;
    [SerializeField] Button raveButton;
    [SerializeField] Button juliusButton;
    Rave rave;
    Julius julius;
   

    void Start()
    {
        //rave = GameObject.FindGameObjectWithTag("Player").GetComponent<Rave>();
        //julius = GameObject.FindGameObjectWithTag("Player").GetComponent<Julius>();
    }

    void Update()
    {

    }

    public void OnClickChooseJulius()
    {
        isJulius = true;
        isRave = false;
        raveButton.interactable = false;
        juliusButton.interactable = true;
        //Camera.main.GetComponent<PlayerCamera>().target = julius.transform;

    }

    public void OnClickChooseRave()
    {
        isRave = true;
        isJulius = false;
        juliusButton.interactable = false;
        raveButton.interactable = true;
        //Camera.main.GetComponent<PlayerCamera>().target = rave.transform;
        
    }


    //static void SetCharacter()
    //{
    //    if (isRanger == true && isKnight == false)
    //    {
    //        PlayerRanger player = GetComponent<PlayerRanger>();
    //    }
    //}
}
