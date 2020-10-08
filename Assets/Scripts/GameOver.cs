using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    public static GameOver gameOver { get; private set; }

    private void Awake()
    {
        gameOver = this;
    }

    public void RestartFuckingLevel() => Application.LoadLevel(Application.loadedLevel);
}
