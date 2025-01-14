using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Animator _animationController;
    private AudioSource _jumpSound;

    private bool _isGrounded = true;
    private bool _isJumping = false;
    private float groundRadius = 0.2f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animationController = GetComponent<Animator>();
        _jumpSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        CheckingGround();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float movementDirectionX = Input.GetAxis("Horizontal");

        if (movementDirectionX == 0)
            movementDirectionX = _joystick.Horizontal;

        _rigidbody2D.velocity = new Vector2(movementDirectionX * _playerSpeed, _rigidbody2D.velocity.y);

        if (movementDirectionX > 0)
            _animationController.Play("RightMove");
        else if (movementDirectionX == 0)
            _animationController.Play("Idle");
        else
            _animationController.Play("LeftMove");
    }

    public void Jump()
    {
        if (_isGrounded && Time.timeScale != 0 && !_isJumping)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);

            _jumpSound.Play();

            _isJumping = true;
            StartCoroutine(JumpTimeTimer());
        }
    }

    private void CheckingGround()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, _ground);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "MovingPlatform")
            transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovingPlatform")
            transform.parent = null;
    }

    private IEnumerator JumpTimeTimer()
    {
        yield return new WaitForSeconds(0.2f);
        _isJumping = false;
    }
}
