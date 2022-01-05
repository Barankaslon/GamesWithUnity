using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementinPoints : MonoBehaviour
{
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private bool moveRandomly;
    private int currentMoveIndex;
    private Vector3 targetPosition;

    private void Start() 
    {
        SetTargetPosition();
    }

    private void Update() 
    {
        Move();
    }

    void SelectRandomPosition()
    {
        while(movementPoints[currentMoveIndex].position == targetPosition)
        {
            currentMoveIndex = Random.Range(0, movementPoints.Length);
        }

        targetPosition = movementPoints[currentMoveIndex].position;
    }

    void SelectPointToPointPosition()
    {
        if(currentMoveIndex == movementPoints.Length)
            currentMoveIndex = 0;

        targetPosition = movementPoints[currentMoveIndex].position;

        currentMoveIndex++;
    }

    void SetTargetPosition()
    {
        if(moveRandomly)
            SelectRandomPosition();
        else
            SelectPointToPointPosition();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetTargetPosition();
        }
    }
}
