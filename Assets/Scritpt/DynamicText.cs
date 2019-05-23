using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DynamicText : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateText(int score)
    {
        this._text.text = score.ToString();
    }
    public void UpdateText(string newText)
    {
        this._text.text = newText; //sobrecarga
    }
}
