using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingItem : MonoBehaviour
{
    [SerializeField] private Text placementText;
    [SerializeField] private Text placementName;
    [SerializeField] private Text placementScore;


    public void Configuration(int placement, string name, int score)
    {
        this.placementText.text = placement.ToString();
        this.placementName.text = name;
        this.placementScore.text = score.ToString();
    }
}

