using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    public int Coins = 0;
    

    public GUIStyle myStyle;

    
        void Start()
    {
        myStyle.font = (Font)Resources.Load("BACKTO1982");
        myStyle.fontSize = 40;
        myStyle.normal.textColor = Color.magenta;



    }
    public void AddCoins()
    {
        Coins++;
        print(Coins);
        SoundManagerScript.PlaySound("Reward");

    }
    private void OnGUI()
    {
        GUI.Label(new Rect(150, 20, 200, 20), ""+ Coins, myStyle);
    }
    
    

}