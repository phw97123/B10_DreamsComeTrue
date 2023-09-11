using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillObjectMove : MonoBehaviour
{
    private bool _isSee = false;
    private bool _isRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -3.5 && transform.position.x > 3.5)
        {
            _isSee = false;
            _isRight = true;
        }

        if (_isSee)
        {
            Move();
        }
    }

    void Move()
    {

    }
}
