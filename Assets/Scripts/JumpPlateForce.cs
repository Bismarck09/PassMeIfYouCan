using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlateForce : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector2 _forceDirection;
    [SerializeField] private AudioSource _jumpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().AddForce(_forceDirection * _jumpForce);
            _jumpSound.Play();
        }
    }
}
