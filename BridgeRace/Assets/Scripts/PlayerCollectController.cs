using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    private PlayerBrickController brickController;
    private BrickGenerator brickGenerator;
    private BotController botController;

    public string playerColorName;

    [SerializeField]
    private bool isBot;

    private void Start()
    {
        brickController = GetComponent<PlayerBrickController>();
        brickGenerator = GameObject.FindObjectOfType<BrickGenerator>();

        if (isBot)
        {
            botController = gameObject.GetComponent<BotController>();
        }
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

        if (isBot)
        {
            botController.CollectBrick();
        }
    }
}
