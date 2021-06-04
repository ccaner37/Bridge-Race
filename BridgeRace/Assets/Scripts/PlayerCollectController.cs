using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    PlayerBrickController brickController;

    private void Start()
    {
        brickController = GetComponent<PlayerBrickController>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        Brick brick = other.transform.GetComponent<Brick>();

        if (brick != null)
        {
            Destroy(other.gameObject);
            brickController.UpdatePlayerBricks();
        }
    }
}
