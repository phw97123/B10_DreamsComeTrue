using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ObjectsFall : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyFall();
        if(transform.position.y < -5.5)
        {
            gameObject.SetActive(false);
        }
    }

    private void ApplyFall()
    {
        Vector2 direction = new Vector2(0,-1) * speed;
        _rigidbody.velocity = direction;
    }
}
