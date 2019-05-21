using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int _score;
    public int scoreToRanking
    {
        get
        {
            return this._score;
        }
    }
    [SerializeField] private PersonalizedEvent onScore;
    public void AddScore(int score)
    {
        this._score++;
        this.onScore.Invoke(this._score);
    }
}

[System.Serializable]
public class PersonalizedEvent : UnityEvent<int>
{

}
