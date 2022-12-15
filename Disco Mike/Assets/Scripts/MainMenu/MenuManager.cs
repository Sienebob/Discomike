using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject panel;
    

    public GameObject image;

    
    






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayFinalScene()
    {
        SceneManager.LoadScene("End");

    }
    public void ExitNow()
    {
        Application.Quit();

        print("Q U I T   G A M E");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");

    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        print("Menee main menuun");
    }
    

    public void ShowOptions() 
    {
        
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }


    }
    public void ShowPauseMenu()
    {
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }


    }
    public void ShowMainMenu()
    {
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);

        }
        else
        {
            panel.SetActive(false);
                
        }

    }
    private bool paused = false;

    public void Pause()
    {
        Debug.Log("PAUSE");
        ShowPauseMenu();

       Time.timeScale = 0;
       paused = true;
       
    }

    public void Resume()
    {
        Debug.Log("RESUME");
        ShowPauseMenu();

        Time.timeScale = 1;
        paused = false;

    }
    

   


    

}

