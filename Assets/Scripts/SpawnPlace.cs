using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnPlace : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPointImage;
    [SerializeField] private TextMeshProUGUI _numberOfSpawnPointText;
    [SerializeField] private GameObject _player;

    private Vector2 _spawnPointPosition;
    private GameObject _spawnPoint;

    private void Start()
    {
        _numberOfSpawnPointText.text = Progress.Instance.SpawnPoints.ToString();

        _spawnPointPosition = _player.transform.position;
    }

    public void PutSpawnPoint()
    {
        if (Progress.Instance.SpawnPoints >= 1)
        {
            Destroy(_spawnPoint);
            _spawnPointPosition = _player.transform.position;
            _spawnPoint = Instantiate(_spawnPointImage, new Vector2(_player.transform.position.x, _player.transform.position.y + 0.73f), _player.transform.rotation);

            Progress.Instance.SpawnPoints -= 1;
            _numberOfSpawnPointText.text = Progress.Instance.SpawnPoints.ToString();
            PlayerPrefs.SetInt("NumberOfSpawnPoint", Progress.Instance.SpawnPoints);
        }
    }

    public Vector3 GetSpawnPointPosition()
    {
        return new Vector3(_spawnPointPosition.x, _spawnPointPosition.y + 0.5f, 0);
    }
}
