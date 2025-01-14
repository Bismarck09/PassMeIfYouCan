using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 _target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.transform.position = _target;
    }
}
