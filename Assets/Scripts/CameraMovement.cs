
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _cameraSpeed;

    private void Start()
    {
        transform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y, _playerTransform.position.z - 10);
    }

    private void LateUpdate()
    {
        StalkingPlayer();
    }

    private void StalkingPlayer()
    {
        Vector3 target = new Vector3(_playerTransform.position.x, _playerTransform.position.y, _playerTransform.position.z - 10);
        Vector3 playerPosition = Vector3.Lerp(transform.position, target, _cameraSpeed * Time.deltaTime);

        transform.position = playerPosition;
    }
}
