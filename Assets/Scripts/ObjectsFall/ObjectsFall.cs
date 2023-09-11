using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ObjectsFall : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rigidbody;
    private float x;
    private float y;

    private void Awake()
    {
        speed = Random.Range(4, 10);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    private void FixedUpdate()
    {
        ApplyFall();
        if (transform.position.y < -5.5)
        {
            transform.position = new Vector3(x, y, 0);
            gameObject.SetActive(false);
        }
    }

    private void ApplyFall()
    {
        Vector2 direction = new Vector2(0, -1) * speed;
        _rigidbody.velocity = direction;
    }
}
