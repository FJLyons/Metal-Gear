using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Movement : MonoBehaviour {

    Rigidbody2D rBody;
    Animator anim;

    float speed = 50;

    Vector2 previousVector;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        previousVector = new Vector2();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move() {
        Vector2 movementVector = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")
        );

        if (movementVector != Vector2.zero)
        {
            if (movementVector.x != 0 && movementVector.y != previousVector.y)
            {
                movementVector.y = 0;
            }

            if (movementVector.y != 0 && movementVector.x != previousVector.x)
            {
                movementVector.x = 0;
            }

            anim.SetBool("IsWalking", true);
            anim.SetFloat("Input_X", movementVector.x);
            anim.SetFloat("Input_Y", movementVector.y);
        }

        else
        {
            anim.SetBool("IsWalking", false);
        }

        rBody.MovePosition(rBody.position + (movementVector * Time.deltaTime) * speed);

        previousVector = movementVector;
    }
}
