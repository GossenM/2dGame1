using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Burst.CompilerServices;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Julius julius;
    [SerializeField] Button katanaDmgIncreaseBTN;
    [SerializeField] Button healthIncreaseBTN;
    [SerializeField] TMP_Text goldCoinsTXT;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] PlayerCamera playerCamera;
    [SerializeField] GameObject heroMenu;


    public static SaveData saveData;
    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");

    private void Awake()
    {
        if (saveData == null)
            Load();
        else
            Save();
        
    }
    private void Load()
    {
        FileStream file = null;
        try
        {
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = bf.Deserialize(file) as SaveData;
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            saveData = new SaveData();
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }
    private void Save()
    {
        FileStream file = null; 
        try 
        { 
            if (!Directory.Exists(Application.persistentDataPath)) 
               Directory.CreateDirectory(Application.persistentDataPath);

            file = File.Create(SavePath);
            var bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
        }

        catch (Exception e) 
        { 
            Debug.Log(e);
        } 

        finally 
        { 
            if (file != null) 
                file.Close(); 
        }
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Game");        
    }
    public void RetryBtn()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpgradeBtn()
    {
        SceneManager.LoadScene("Upgrade");

    }
    public void HeroesBtn()
    {
        heroMenu.SetActive(true);
    }

    public void QuitBtn()
    {
        Application.Quit(); 
    }
    public void ReturnBtn()
    {
        SceneManager.LoadScene("Title");
        
    }

    public void KatanaLVL()
    {
        julius.weapons[0].levelUp();
        LevelUpandPlay();

    }
    public void ScythLVL()
    {
        julius.weapons[1].levelUp();
        LevelUpandPlay();
    }
    public void EnergyLVL()
    {
        julius.weapons[2].levelUp();
        LevelUpandPlay();
    }
    public void HPBuffLVL()
    {
        julius.weapons[3].levelUp();
        LevelUpandPlay();
    }
    public void SpeedBuffLVL()
    {
        julius.weapons[4].levelUp();
        LevelUpandPlay();
    }
    public void HealthIncrease()
    {
        if (TitleManager.saveData.goldCoins < 25)
        {
            healthIncreaseBTN.interactable = false;
        }
        else
        {
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 25;
            TitleManager.saveData.healthIncrease++;
        }
    }
    public void KatanaDmgIncrease()
    {
        if (TitleManager.saveData.goldCoins < 100)
        {
            katanaDmgIncreaseBTN.interactable = false;
        }
        else
        {
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 100;
            TitleManager.saveData.katanaDmgIncrease++;
        }
    }
    public void LevelUpandPlay()
    {
        julius.levelUpMenu.SetActive(false);
        Time.timeScale = 1;
        particleSystem.Play();
        playerCamera.depthOfField.focalLength.Override(1);
    }

}