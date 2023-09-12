using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerMoveMent : MonoBehaviour
{
    private PlayerController _controller;
    private Animator _anim; 

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    public float Speed = 1;
    public float StunTime = 1;
    public float JumpForce = 7; //�����ϴ� �� 

    //���� ��Ҵ��� 
    bool _isGrounded = true; 

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>(); 
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.onJumpEvent += Jump; //���� �̺�Ʈ �߰� 
    }


    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void Jump()
    {
        if (_isGrounded) // ���� ��� �ִٸ� 
        {
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse); // ���� ���� * ������ ��, ª�� ���� ������� ���� ����
            _isGrounded = false; //���� ������� ����
            _anim.SetBool("IsJump", true); 
        }
    }

    //Player�� Ground �±׸� ���� ������Ʈ�� �浹 ���� �� true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _anim.SetBool("IsJump", false);
        }
    }

    private void ApplyMovement(Vector2 direction)
    {
        //direction = direction * 3 * Speed;
        //_rigidbody.velocity = direction;

        //�¿� ������ ������ �����ϰ�, ���� ������ �ӵ��� ������ �����ϰ� �����Ͽ� ���� ������ �ӵ��� ������� �ʰ� ���� 
        _rigidbody.velocity = new Vector2(direction.x *3 *Speed, _rigidbody.velocity.y); 
    }
}
