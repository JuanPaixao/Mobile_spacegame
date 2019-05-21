using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // to use Guid 

public class NewScore : MonoBehaviour
{
    [SerializeField] private DynamicText _text;
    private GameManager _scoreText;
    [SerializeField] private Ranking _ranking;
    private string _id;

    private void Start()
    {
        this._scoreText = GameObject.FindObjectOfType<GameManager>();

        int totalScore = -1;

        if (this._scoreText != null)
        {
            totalScore = this._scoreText.scoreToRanking;
        }

        this._text.UpdateScore(totalScore);
        this._id = this._ranking.AddToRankingList(totalScore, "Name");
    }
    public void ChangeName(string name)
    {
        this._ranking.ChangeName(name, this._id);
    }
}
