using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform camTransform;

    [SerializeField]
    private Vector3 Offset;
    [SerializeField]
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float SmoothTime = 0.3f;

    void Start()
    {
        Offset = camTransform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + Offset;
        targetPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
    }
}