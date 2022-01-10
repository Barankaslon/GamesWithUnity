using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 5f, maxSpeed = 10f;
    private bool moveOn_X;

    private float speed_X, speed_Y;

    private float rotationSpeed = 5f;

    private float zRotation;

    private Vector3 tempPos;


    private void Awake()
    {
        speed_Y = Random.Range(minSpeed, maxSpeed);
        speed_X = speed_Y;

        if(Random.Range(0, 2) > 0)
            moveOn_X = true;
    }

    void HandleMovement()
    {
        tempPos = transform.position;
        tempPos.y -= speed_Y * Time.deltaTime;
        transform.position = tempPos;

        if(!moveOn_X)
            return;
        
    }
}
