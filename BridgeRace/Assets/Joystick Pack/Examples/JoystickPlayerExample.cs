using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public DynamicJoystick variableJoystick;
    public Rigidbody rb;

    public CharacterController characterController;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        // rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        characterController.Move(direction * speed * Time.fixedDeltaTime);

        float angleA = Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, angleA, 0f);
    }
}