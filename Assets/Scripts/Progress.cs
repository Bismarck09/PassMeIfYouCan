using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public int Coins;
    public int SpawnPoints;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Coins = PlayerPrefs.GetInt("NumberOfCoins");
        SpawnPoints = PlayerPrefs.GetInt("NumberOfSpawnPoint");
    }
}
