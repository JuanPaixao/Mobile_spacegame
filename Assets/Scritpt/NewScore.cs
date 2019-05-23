using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // to use Guid 

public class NewScore : MonoBehaviour
{
    [SerializeField] private DynamicText _text;
    [SerializeField] private DynamicText _nameText;
    private GameManager _scoreText;
    [SerializeField] private Ranking _ranking;
    private string _id;

    private void Start()
    {
        int totalScore = this.GetScore();
        string playerName = this.GetName();
        this._text.UpdateText(totalScore);
        this._nameText.UpdateText(playerName);
        this._id = this._ranking.AddToRankingList(totalScore, playerName);


    }

    private string GetName()
    {
        if (PlayerPrefs.HasKey("LastNameSaved"))
        {
            return PlayerPrefs.GetString("LastNameSaved");
        }
        else
        {
            return "Name";
        }
    }


    private int GetScore()
    {
        this._scoreText = GameObject.FindObjectOfType<GameManager>();
        int totalScore = -1;

        if (this._scoreText != null)
        {
            totalScore = this._scoreText.scoreToRanking;
        }

        return totalScore;
    }

    public void ChangeName(string name)
    {
        this._ranking.ChangeName(name, this._id);
        PlayerPrefs.SetString("LastNameSaved", name);
    }
}
