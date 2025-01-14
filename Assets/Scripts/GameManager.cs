using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameOfCoins _gameOfCoins;
    [SerializeField] private SpawnPlace _spawnPosition;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioSource _backgroundSound;

    private int _sceneIndex;
    private int _levelComplete;
    private bool _isAdvShow;

    private void Start()
    {
        _levelText.text = SceneManager.GetActiveScene().name;

        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadScene()
    {
        _isAdvShow = false;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Time.timeScale = 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
            _gameOfCoins.AddCoinsAtEndOfLevel();
            _backgroundSound.Play();

            if (_levelComplete < _sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", _sceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            _gameOfCoins.AddCoinsAtEndOfLevel();
        }
    }

    public void PressingPause()
    {
        _pauseWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinuationOfGame()
    {
        _pauseWindow.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
        ContinuationOfGame();
    }

    public void RestartGame()
    {
        _player.transform.position = _spawnPosition.GetSpawnPointPosition();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus && !_isAdvShow)
        {
            _backgroundSound.Pause();
        }
        else if (focus && !_isAdvShow)
        {
            _backgroundSound.Play();
        }
    }
}
