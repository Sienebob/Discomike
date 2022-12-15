using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishExit : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("theend", 3f);

        }
    }


    private void theend()
    { 
        SceneManager.LoadScene("MainMenu");
    }







}
