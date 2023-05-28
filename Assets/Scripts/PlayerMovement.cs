using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    public float speed = 12f;

    public float yLocation = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller  = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;

        // Get the right vector relative to the camera's forward vector
        Vector3 cameraRight = cameraTransform.right;

        Vector3 move = cameraForward.normalized * z + cameraRight.normalized * x;

        Vector3 horizontalMove = new Vector3(move.x, 0, move.z);

        controller.Move(horizontalMove * speed * Time.deltaTime);
   
        transform.position = new Vector3(transform.position.x, yLocation, transform.position.z);

    }
}
