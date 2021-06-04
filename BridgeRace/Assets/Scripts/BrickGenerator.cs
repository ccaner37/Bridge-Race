using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform BrickPrefab;

    private Vector3 startPoint;
    private Vector3 position;

    private int length = 12;
    private int line = 4;
    private int xOrder = 0;

    private float zPosition;
    private float xPosition;

    void Start()
    {
        startPoint = transform.position;
        zPosition = transform.position.z;
        xPosition = transform.position.x;

        CreateBricks();
    }

    private void CreateBricks()
    {
        for (int i = 0; i < length; i++)
        {
            xOrder++;
            if (i % line == 0)
            {
                zPosition -= 1;
                xOrder = 0;
                position = new Vector3(xPosition, startPoint.y, zPosition);
            }
            else
            {
                position = new Vector3(xPosition + xOrder, startPoint.y, zPosition);
            }

            Instantiate(BrickPrefab, position, BrickPrefab.transform.rotation);
        }
    }

}
