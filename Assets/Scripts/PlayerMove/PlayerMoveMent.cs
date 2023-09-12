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
    public float JumpForce = 7; //점프하는 힘 

    //땅에 닿았는지 
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
        _controller.onJumpEvent += Jump; //점프 이벤트 추가 
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
        if (_isGrounded) // 땅에 닿아 있다면 
        {
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse); // 위쪽 방향 * 점프할 힘, 짧고 강한 충격으로 힘을 가함
            _isGrounded = false; //땅에 닿아있지 않음
            _anim.SetBool("IsJump", true); 
        }
    }

    //Player가 Ground 태그를 가진 오브젝트와 충돌 했을 때 true
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

        //좌우 방향의 속조를 설정하고, 상하 방향의 속도는 이전과 동일하게 유지하여 상하 방향의 속도가 변경되지 않게 설정 
        _rigidbody.velocity = new Vector2(direction.x *3 *Speed, _rigidbody.velocity.y); 
    }
}
