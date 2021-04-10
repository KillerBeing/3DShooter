using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{


    


    public bool paused = true;

    public delegate void eventHandeler();

    public event eventHandeler StartGame;
    public event eventHandeler PauseGame;

    public void CallStartGame() => StartGame?.Invoke();
    public void CallPauseGame() => PauseGame?.Invoke();

    private static GameManager instance;
    protected GameManager(){}

    public static GameManager i
	{
		get
		{
            if (instance == null) instance = new GameManager();
            return instance;
		}
	}

    
	
}
