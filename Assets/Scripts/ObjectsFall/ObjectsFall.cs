using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ObjectsFall : MonoBehaviour
{
    public static float speed;
    private Rigidbody2D _rigidbody;
    private float x;
    private float y;

    private void Awake()
    {    
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed = Random.Range(1 + GameManager.Instance.fallMiniSpeed, 6 + GameManager.Instance.fallMaxSpeed);
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
