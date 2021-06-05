using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform BrickPrefab;

    private Vector3 startPoint;
    private Vector3 position;

    private int length = 24;
    private int line = 6;
    private int xOrder = 0;

    private float zPosition;
    private float xPosition;

    [System.Serializable]
    public class ColorData
    {
        public Color color;
        public string colorName;
    }
    public ColorData[] colorArray;

    [System.Serializable]
    public class SpawnedBricks
    {
        public Color color;
        public string colorName;
        public Vector3 position;
        public bool removed;
    }
    public SpawnedBricks[] spawnedBricks;

    void Start()
    {
        startPoint = transform.position;
        zPosition = transform.position.z;
        xPosition = transform.position.x;

        spawnedBricks = new SpawnedBricks[length];

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

            Transform createdBrick = Instantiate(BrickPrefab, position, BrickPrefab.transform.rotation, transform);
            GiveColor(createdBrick, i);
        }
    }

    private void GiveColor(Transform createdBrick, int i)
    {
        int randomColor = Random.Range(0, colorArray.Length);
        createdBrick.GetComponent<Renderer>().material.SetColor("_Color", colorArray[randomColor].color);
        createdBrick.GetComponent<Brick>().colorName = colorArray[randomColor].colorName;
        createdBrick.GetComponent<Brick>().brickNumber = i;

        InsertIntoArray(colorArray[randomColor].color, colorArray[randomColor].colorName, createdBrick, i);
    }

    private void InsertIntoArray(Color _color, string _colorName, Transform createdBrick, int i)
    {
        var tmp = new SpawnedBricks();

        tmp.color = _color;
        tmp.colorName = _colorName;
        tmp.position = createdBrick.position;
        tmp.removed = false;

        spawnedBricks[i] = tmp;
    }

    public void MakeRemoved(int brickNumber)
    {
        spawnedBricks[brickNumber].removed = true;
    }

    public void GenerateRemovedBrick()
    {
        for (int i = 0; i < length; i++)
        {
            if (spawnedBricks[i].removed == true)
            {
                Transform createdBrick = Instantiate(BrickPrefab, spawnedBricks[i].position, BrickPrefab.transform.rotation, transform);

                createdBrick.GetComponent<Renderer>().material.SetColor("_Color", spawnedBricks[i].color);
                createdBrick.GetComponent<Brick>().colorName = spawnedBricks[i].colorName;
                createdBrick.GetComponent<Brick>().brickNumber = i;

                spawnedBricks[i].removed = false;
                return;
            }
        }
    }
}
