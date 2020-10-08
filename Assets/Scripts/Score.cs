using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreT;
    private int score;
    private RecordLoadAndSave _recordLoadAndSave;

    private void Start()
    {
        _recordLoadAndSave = GetComponent<RecordLoadAndSave>();
        ShowScoreT();
        _recordLoadAndSave.ShowRecord();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            score++;
            ShowScoreT();
            if (_recordLoadAndSave.recordCl.Record < score)
            {
                _recordLoadAndSave.recordCl.Record = score;
                _recordLoadAndSave.ShowRecord();
            }
        }
    }

    private void ShowScoreT() => ScoreT.text = score.ToString() + " score";
}
