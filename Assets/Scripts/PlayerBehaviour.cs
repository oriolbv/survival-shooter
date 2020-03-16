using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed;

    private Camera mainCamera;
    void Start()
    {
        animator = GetComponent<Animator>();

        moveSpeed = 3f;

        mainCamera = FindObjectOfType<Camera>();
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

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
