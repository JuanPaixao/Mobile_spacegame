using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreable : MonoBehaviour
{
    private GameManager _gameManager;
    private int myScore;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    public void AddScorePoint()
    {
        _gameManager.AddScore(myScore);
    }
    public void SetScore(int score)
    {
        this.myScore = score;
    }
}

