using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    BrickGenerator brickGenerator;
    PlayerBrickController[] brickController;

    void Start()
    {
        brickGenerator = FindObjectOfType<BrickGenerator>();
        brickController = FindObjectsOfType<PlayerBrickController>();

        ShuffleColors();
        RandomColors();
    }

    private void RandomColors()
    {
        //int randomColor = Random.Range(0, brickGenerator.colorArray.Length);

        PlayerCollectController[] players = FindObjectsOfType<PlayerCollectController>();

        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", brickGenerator.colorArray[i].color);
            players[i].playerColorName = brickGenerator.colorArray[i].colorName;
            brickController[i].selectedColor = brickGenerator.colorArray[i].color;
            brickController[i].selectedColorName = brickGenerator.colorArray[i].colorName;
        }
    }

    private void ShuffleColors()
    {
        for (int t = 0; t < brickGenerator.colorArray.Length; t++)
        {
            BrickGenerator.ColorData tmp = brickGenerator.colorArray[t];
            int r = Random.Range(t, brickGenerator.colorArray.Length);
            brickGenerator.colorArray[t] = brickGenerator.colorArray[r];
            brickGenerator.colorArray[r] = tmp;
        }
    }
}
