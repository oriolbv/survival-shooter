using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed;
    void Start()
    {
        animator = GetComponent<Animator>();

        moveSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isMoving", true);
            transform.Translate(moveSpeed * (Input.GetAxis("Horizontal") * Time.deltaTime), 0f, moveSpeed * (Input.GetAxis("Vertical") * Time.deltaTime));
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
