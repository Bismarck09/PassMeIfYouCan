using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOfCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numbetOfCoinsText;

    private void Start()
    {
        _numbetOfCoinsText.text = Progress.Instance.Coins.ToString();
    }

    public void AddCoinsAtEndOfLevel()
    {
        Progress.Instance.Coins += 50;
        _numbetOfCoinsText.text = Progress.Instance.Coins.ToString();
        PlayerPrefs.SetInt("NumberOfCoins", Progress.Instance.Coins);

    }
}
