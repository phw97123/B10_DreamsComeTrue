using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerKillObjectMove : MonoBehaviour
{
    private bool _isSee = false;
    private bool _isRight = true;
    private int _spead;
    private float _x;
    private float _time = 0;
    float _sleepTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isSee)
        {
            Move();
        }
        else
        {
            if (_isRight)
            {
                int dir = 0;
                while (dir == 0)
                {
                    dir = Random.Range(-1, 2);
                }
                _spead = 4 * dir;
                _x = -3.45f * dir;
                _isRight = false;
            }
            transform.position = new Vector3(_x, -4f, 1);
            _time += Time.deltaTime;
            if (_sleepTime < _time)
            {
                _isSee = true;
                _time = 0;
            }
        }
    }

    private void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(_spead, 0);
        if (transform.position.x < -3.5 || transform.position.x > 3.5)
        {
            _isSee = false;
            _isRight = true;
            _sleepTime = Random.Range(1.5f, 3f); //1.5 ~ 3 √  ªÁ¿Ã
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _spead *= -1;
        }
    }
}
