using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrickController : MonoBehaviour
{
    public float bricks;
    private float brickCount;

    [SerializeField]
    private Transform dummyBrick;
    [SerializeField]
    private Transform placedBrick;

    [SerializeField]
    private Transform brickArea;
    [SerializeField]
    private Transform brickPlacer;

    private Vector3 bridgePos;

    void FixedUpdate()
    {
        CheckBridge();
    }

    private void CheckBridge()
    {
        RaycastHit hit;
        if (Physics.Raycast(brickPlacer.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(brickPlacer.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);

            if (hit.collider.tag == "Bridge")
            {
                if (bricks > 0)
                {
                    PlaceBricks(hit);
                }
                else
                {
                    BlockFallOff();
                }
            }

        }
        else
        {
            Debug.DrawRay(brickPlacer.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void PlaceBricks(RaycastHit hit)
    {
        brickCount = hit.collider.GetComponent<WayKeeper>().bricksPlaced;

        bridgePos = hit.collider.transform.position;

        Vector3 brickPlacement = new Vector3(bridgePos.x, bridgePos.y + (brickCount * 0.30f), bridgePos.z + (brickCount * 0.65f));

        Instantiate(placedBrick, brickPlacement, placedBrick.transform.rotation);

        hit.collider.GetComponent<WayKeeper>().bricksPlaced += 1;

        RemoveDummyBrick();
    }

    private void BlockFallOff()
    {
        Vector3 playerPosition = transform.position;

        if (transform.position.z > bridgePos.z + (brickCount * 0.70f))
        {
            playerPosition.z = bridgePos.z + (brickCount * 0.70f);
        }

        transform.position = playerPosition;
    }

    private void RemoveDummyBrick()
    {
        GameObject lastChild = brickArea.GetChild(brickArea.childCount - 1).gameObject;
        Destroy(lastChild);
        bricks--;
    }

    public void UpdatePlayerBricks()
    {
        Vector3 brickPosition = new Vector3(brickArea.position.x, brickArea.position.y + (bricks * 0.1f), brickArea.position.z);
        Instantiate(dummyBrick, brickPosition, dummyBrick.transform.rotation, brickArea);
        bricks++;
    }
    private void Update()
    {
        brickArea.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }
}
