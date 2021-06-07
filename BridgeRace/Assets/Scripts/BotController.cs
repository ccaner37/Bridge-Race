using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private PlayerBrickController brickController;
    private BrickGenerator brickGenerator;

    [SerializeField]
    private Transform finalPoint;
    [SerializeField]
    private Transform startPoint;

    private Vector3 finalPointPos; 

    private int selectedColorBrickCount;

    private void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        brickController = gameObject.GetComponent<PlayerBrickController>();
        brickGenerator = FindObjectOfType<BrickGenerator>();

        StartCoroutine(FirstCollect());
        finalPointPos = finalPoint.position;
    }

    public void CollectBrick()
    {
        BrickGenerator.SpawnedBricks[] spawnedBricks = brickGenerator.spawnedBricks;

        if (brickController.bricks < selectedColorBrickCount - 3)
        {
            for (int i = 0; i < spawnedBricks.Length; i++)
            {
                if (spawnedBricks[i].removed != true && spawnedBricks[i].colorName == brickController.selectedColorName)
                {
                    navMeshAgent.SetDestination(spawnedBricks[i].position);
                    print("Found brick:" + spawnedBricks[i].colorName + " --- " + spawnedBricks[i].position);
                    return;
                }
            }
        }
        else
        {
            PlaceOrCollectBricks();
        }
    }

    public void PlaceOrCollectBricks()
    {
        if (brickController.bricks == 0)
        {

            //navMeshAgent.isStopped = true;

            // ýþýnlýyor aþaðý navMeshAgent.ResetPath();

            //navMeshAgent.SetDestination(transform.position);

            //navMeshAgent.Warp(transform.position);

            // gameObject.GetComponent<NavMeshAgent>().enabled = true;

            //finalPoint.position = transform.position;
            //navMeshAgent.SetDestination(startPoint.position);
            //navMeshAgent.CompleteOffMeshLink();

            CollectBrick();
        }
        else
        {
            //finalPoint.position = finalPointPos;
            navMeshAgent.SetDestination(finalPoint.position);
        }
    }

    public void UpdateMesh()
    {
        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }

    private IEnumerator FirstCollect()
    {
        yield return new WaitForSeconds(1f);

        BrickGenerator.SpawnedBricks[] spawnedBricks = brickGenerator.spawnedBricks;

        for (int i = 0; i < spawnedBricks.Length; i++)
        {
            if (spawnedBricks[i].colorName == brickController.selectedColorName)
            {
                selectedColorBrickCount++;
            }
        }

        if (brickController.bricks < selectedColorBrickCount)
        {
            for (int i = 0; i < spawnedBricks.Length; i++)
            {
                if (spawnedBricks[i].removed != true && spawnedBricks[i].colorName == brickController.selectedColorName)
                {
                    navMeshAgent.SetDestination(spawnedBricks[i].position);
                    print("Found brick:" + spawnedBricks[i].colorName + " --- " + spawnedBricks[i].position);
                    StopCoroutine(FirstCollect());
                }
            }
        }
    }
}
