using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrafabs : MonoBehaviour
{
    public Text scoreText;
    public Text playerNameText;
    public InputField enteredname;

    public int score = 0;
    public string playername;

    private void Start()
    {
        //score = PlayerPrefs.GetInt("FinalScore");
        playername = PlayerPrefs.GetString("MyPlayerName");

        playerNameText.text = playername;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        playername = enteredname.text;
        if (Input.GetKeyDown(KeyCode.X))
        {
            score += 10;
            PlayerPrefs.SetInt("FinalScore", score);
           
        }
        PlayerPrefs.SetString("MyPlayerName", playername);
    }
}

//number of coins:= 
//    high score:100;
