using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bird : MonoBehaviour
{
    public float PowerJump;

    public float MinPositionY, MaxPositionY;
    
    private Rigidbody rb;
    private RecordLoadAndSave _recordLoadAndSave;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _recordLoadAndSave = GetComponent<RecordLoadAndSave>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y >= MaxPositionY || transform.position.y <= MinPositionY)
        {
            _recordLoadAndSave.SaveRecord();
            GameOver.gameOver.RestartFuckingLevel();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _recordLoadAndSave.SaveRecord();
            GameOver.gameOver.RestartFuckingLevel();
        }
    }

    public void Jump() => rb.AddForce(Vector3.up * PowerJump, ForceMode.Impulse);
    
}
