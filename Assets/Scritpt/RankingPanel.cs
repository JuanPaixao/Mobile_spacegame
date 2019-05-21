using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;
using UnityEngine.UI;

public class RankingPanel : MonoBehaviour
{
    [SerializeField] private Ranking _ranking;
    [SerializeField] private GameObject _rankingPrefab;
    void Start()
    {
        ReadOnlyCollection<PlayerRank> playerData = this._ranking.GetPlayersRank();

        for (int i = 0; i < playerData.Count; i++)
        {
            if (i >= 5)
            {
                break;
            }
            GameObject playerOnRanking = GameObject.Instantiate(this._rankingPrefab, this.transform);
            playerOnRanking.GetComponent<RankingItem>().Configuration(i, playerData[i].playerName, playerData[i].playerScores);
        }
    }
}
