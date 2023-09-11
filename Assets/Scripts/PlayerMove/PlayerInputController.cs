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
        Debug.Log("¾È³ç");
        /*if (value.Get<Vector2>().magnitude < 0)
        {
            transform.Find("MainSprite").gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.Find("MainSprite").gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }*/

        if (moveInput.magnitude > 0.5)
        {
            GetComponent<Animator>().SetBool("Move", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Move", false);
        }
    }

    
}
