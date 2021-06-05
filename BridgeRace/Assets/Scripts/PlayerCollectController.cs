using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    PlayerBrickController brickController;
    BrickGenerator brickGenerator;

    private string playerColorName;

    private void Start()
    {
        brickController = GetComponent<PlayerBrickController>();
        brickGenerator = GameObject.FindObjectOfType<BrickGenerator>();

        PlayerRandomColor();
    }

    private void PlayerRandomColor()
    {
        int randomColor = Random.Range(0, brickGenerator.colorArray.Length);
        transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", brickGenerator.colorArray[randomColor].color);
        playerColorName = brickGenerator.colorArray[randomColor].colorName;
        brickController.selectedColor = brickGenerator.colorArray[randomColor].color;
    }

    private void OnTriggerEnter(Collider other)
    {
        Brick brick = other.transform.GetComponent<Brick>();

        if (brick.colorName == playerColorName)
        {
            brickGenerator.MakeRemoved(brick.brickNumber);
            Destroy(other.gameObject);
            brickController.UpdatePlayerBricks();
        }
    }
}
