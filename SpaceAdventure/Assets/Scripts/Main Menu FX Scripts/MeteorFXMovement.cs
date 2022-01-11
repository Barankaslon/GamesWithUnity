using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 20f, maxSpeed = 35f;
    [SerializeField] private float minRotationSpeed = 10f, maxRotationSpeed = 20f;
    private bool moveOn_X;

    private float speed_X, speed_Y;


    private float zRotation;

    private float rotationSpeed;

    private Vector3 tempPos;

    [HideInInspector] public bool moveDown;


    private void Awake()
    {
        speed_Y = Random.Range(minSpeed, maxSpeed);
        speed_X = speed_Y;

        if(Random.Range(0, 2) > 0)
            moveOn_X = true;

        if(Random.Range(0, 2) > 0)
            speed_X *= -1f;

        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        if(Random.Range(0, 2) > 0)
            rotationSpeed *= -1;
    }

    private void Start()
    {
        if(moveDown)
            speed_Y *= -1f;
    }

    private void Update()
    {
        HandleMovement();

        HandleRotation();
    }

    void HandleMovement()
    {
        tempPos = transform.position;
        tempPos.y += speed_Y * Time.deltaTime;
        transform.position = tempPos;

        if(!moveOn_X)
            return;

        tempPos = transform.position;
        tempPos.x -= speed_X * Time.deltaTime;
        transform.position = tempPos;
        
    }

    void HandleRotation()
    {
        zRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }
}
