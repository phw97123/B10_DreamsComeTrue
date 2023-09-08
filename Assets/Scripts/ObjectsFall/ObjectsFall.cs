using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ObjectsFall : MonoBehaviour
{
    private int speed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        speed = Random.Range(4, 8);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyFall();
    }

    private void ApplyFall()
    {
        Vector2 direction = new Vector2(0,-1) * speed;
        _rigidbody.velocity = direction;
    }
}
