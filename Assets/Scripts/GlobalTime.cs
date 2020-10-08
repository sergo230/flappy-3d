using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTime : MonoBehaviour
{
     private void Start()
     {
          Time.timeScale = 0;
     }

     public void StartGame() => Time.timeScale = Time.timeScale == 0 ? 2 : Time.timeScale;
}
