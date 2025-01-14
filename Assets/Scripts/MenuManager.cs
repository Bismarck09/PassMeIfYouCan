using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _numberOfCoinText;
    [SerializeField] TextMeshProUGUI _numberOfSpawnPointText;

    private void Start()
    {
        _numberOfCoinText.text = Progress.Instance.Coins.ToString();
        _numberOfSpawnPointText.text = Progress.Instance.SpawnPoints.ToString();
    }

    public void WatchAds()
    {
        Progress.Instance.Coins += 25;
        _numberOfCoinText.text = Progress.Instance.Coins.ToString();
        PlayerPrefs.SetInt("NumberOfCoins", Progress.Instance.Coins);
    }

    public void BuySpawnPoint()
    {
        if (Progress.Instance.Coins >= 50)
        {
            Progress.Instance.Coins -= 50;
            _numberOfCoinText.text = Progress.Instance.Coins.ToString();

            Progress.Instance.SpawnPoints += 1;
            _numberOfSpawnPointText.text = Progress.Instance.SpawnPoints.ToString();

            PlayerPrefs.SetInt("NumberOfCoins", Progress.Instance.Coins);
            PlayerPrefs.SetInt("NumberOfSpawnPoint", Progress.Instance.SpawnPoints);

        }
    }
}
