using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    PlayerBrickController brickController;
    BrickGenerator brickGenerator;

    public string playerColorName;

    private void Start()
    {
        brickController = GetComponent<PlayerBrickController>();
        brickGenerator = GameObject.FindObjectOfType<BrickGenerator>();
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
