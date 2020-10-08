using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float SpeedMovement;
    public float MaxPositionX;
    public float MinPositionX;
    [Header("transform.position.y = Random from minY to maxY ")]
    public float MinPositionY, MaxPositionY;

    public float PositionZ;
    
    private void FixedUpdate()
    {
        moveX();
        if (transform.position.x <= MinPositionX)
            returnToStartPotion();
    }

    private void moveX() => transform.Translate(Vector3.left * SpeedMovement);
    
    //return object on the MaxPositionX 
    private void returnToStartPotion()
    {
        float posY = UnityEngine.Random.Range(MinPositionY, MaxPositionY);
        transform.position = new Vector3(MaxPositionX + transform.position.x,posY,PositionZ);
    }

}
