using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public static GameStatus status;
    public static string currentLevel;

    public float health;
    public float previousHealth;
    public float maxHealth;

    public int lives;

    //HUOM! alla olevan muuttujan nimi tulee olla SAMA kuin mitä on
    //LoadLevel scriptin LevelToLoad muuttuja arvo
    //public bool Level1;
    //public bool Level2;
    //public bool Level3;
    

    private void Awake()
    {
        /*
         * tämä varmistaa sen että on olemassa vain yksi GameStatus olio (objecti)
         * jos peli jostain syystä yrittää tehdä toisen instanssin, se tuhotaan heti
         * siitä nimi SIGLETON
         *  
         */
         if(status == null)
        {
            DontDestroyOnLoad(gameObject);
            status = this;
        }
        else
        {
            Destroy(gameObject);
        
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameStatus.currentLevel);

        //jos painentaan pelin aikana 'M' kirjainta, ladataan MainMenu
        if(Input.GetKeyUp(KeyCode.M))
        {
            currentLevel = null;
            SceneManager.LoadScene("MainMenu");
        }

        
    }

}


