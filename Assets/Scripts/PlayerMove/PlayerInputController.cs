using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{   
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        if (moveInput.x < 0)
        {
            transform.Find("MainSprite").gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveInput.x > 0)
        {
            transform.Find("MainSprite").gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (moveInput.magnitude > 0.5)
        {
            GetComponent<Animator>().SetBool("Move", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Move", false);
        }
    }

    public void OnJump()
    {
        CallJumpEvent();
    }
}
