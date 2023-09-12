using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        //OnJump();
    }


    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 3;
        _rigidbody.velocity = direction;
    }
    public void OnJump()
    {
       _rigidbody.AddForce(Vector2.up * 20,ForceMode2D.Impulse);
        //_rigidbody.velocity = new Vector2(_rigidbody.velocity.y, 10);
     //   transform.position = new Vector3(transform.position.x,transform.position.y+2,0);
        Debug.Log(Vector2.up * 20);

    }
}
