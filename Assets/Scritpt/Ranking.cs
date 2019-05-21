using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //to use file methods
using System.Collections.ObjectModel;
using System;
public class Ranking : MonoBehaviour
{
    private static string FILE_NAME = "Ranking.json"; //json to store my savedata
    [SerializeField] private List<PlayerRank> _rankingList; //serialized in order to send to json file
    private string filePath;


    private void Awake()
    {
        this.filePath = Path.Combine(Application.persistentDataPath,
         FILE_NAME); //my file path

        if (File.Exists(this.filePath))
        {
            var jsonText = File.ReadAllText(this.filePath); //read my path to see whats inside 
            JsonUtility.FromJsonOverwrite(jsonText, this); //transform json in an object, which object, and what should be override, in this case, this ranking
        }
        else
        {
            this._rankingList = new List<PlayerRank>(); //if there is no list, create one
        }
    }

    public string AddToRankingList(int score, string name)
    {
        //UUID - GUILD - unique identifer id
        string id = Guid.NewGuid().ToString();//convert to string so unity can serialize and save it on .json file
        PlayerRank newPlayer = new PlayerRank(name, score, id);
        this._rankingList.Add(newPlayer);
        this._rankingList.Sort();
        this.Save();
        return id;
    }
    public void ChangeName(string newName, string id)
    {
        foreach (var item in this._rankingList)
        {
            if (item.id == id)
            {
                item.playerName = newName;
                break;
            }
        }
        this.Save();
    }
    private void Save()
    {
        string jsonText = JsonUtility.ToJson(this, true); //send my whole class to this jsonText file
        File.WriteAllText(this.filePath, jsonText); //write my path and its content

    }
    public ReadOnlyCollection<PlayerRank> GetPlayersRank() //return a List of RankingPlayers that can be read and only read
    {
        return this._rankingList.AsReadOnly();
    }

    public int Quantity()
    {
        return this._rankingList.Count;
    }
}

[System.Serializable]//make this class serializable in order to save it on json file
public class PlayerRank : System.IComparable
{
    public string playerName;
    public int playerScores;
    public string id;

    public PlayerRank(string playerName, int playerScores, string playerID)
    {
        this.playerName = playerName;
        this.playerScores = playerScores;
        this.id = playerID;
    }

    public int CompareTo(object obj) // return < 0 if X is LOWER than the other object
    {                                // return 0 if X is EQUAL to the other object
                                     // return >0 if X is HIGHER than the other object
        var otherObject = obj as PlayerRank;
        return otherObject.playerScores.CompareTo(this.playerScores); //crescent order, if i compare this.object.CompareTo(other.object) it will give me the decrescent order
    }
}
