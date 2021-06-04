using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    CharacterController characterController;
    Vector3 m_EulerAngleVelocity;
    public float m_Speed = 5f;

    private Vector3 startPos;
    public int pixelDistToDetect = 25;
    private bool fingerDown;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        characterController = GetComponent<CharacterController>();
    }

    //void FixedUpdate()
    //{
    //    //Store user input as a movement vector
    //    Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    //    m_EulerAngleVelocity = new Vector3(0, Input.GetAxis("Vertical"), 0);

    //    //Apply the movement vector to the current position, which is
    //    //multiplied by deltaTime and speed for a smooth MovePosition
    //    m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);

    //    Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
    //    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    //}

    void FixedUpdate()
    {



        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            //Vector3 worldPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            ////    print(worldPosition);
            //Vector3 move2 = worldPosition - startPos;
            //Vector3 move = new Vector3(move2.x, move2.z, move2.y);
            //print(move);
            //characterController.Move(move * Time.deltaTime * 5f);



        }

        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            startPos = Vector3.zero;
        }
    }
}


//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            if (Physics.Raycast(ray, out RaycastHit hit))
//            {
//                var target = hit.point;
//target.y = transform.position.y;

//                transform.LookAt(target);
//                characterController.Move(hit.point* Time.deltaTime);
//            }
