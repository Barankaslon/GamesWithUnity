using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 4f, maxSpeed = 10f;
    [SerializeField] private float minRotationSpeed = 15f, maxRotationSpeed = 50f;

    private float speed_X, speed_Y;
    private bool moveOn_X, moveOn_Y = true;
    private float rotationSpeed;
    private float z_Rotation;
    private Vector3 tempMovement;

    private void Awake()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        speed_X = Random.Range(minSpeed, maxSpeed);
        speed_Y = speed_X;

        if(Random.Range(0, 2) > 0)
            speed_X *= -1f;
        
        if(Random.Range(0, 2) > 0)
            rotationSpeed *= -1f;

        if(Random.Range(0, 2) > 0)
            moveOn_X = true;
    }

    private void Update()
    {
        HandleMovementX();
        HandleMovementY();

        RotateMeteor();
    }

    void HandleMovementX()
    {
        if(!moveOn_X)
            return;
        
        tempMovement = transform.position;
        tempMovement.x += speed_X * Time.deltaTime;
        transform.position = tempMovement;
    }

    void HandleMovementY()
    {
        if(!moveOn_Y)
            return;
        
        tempMovement = transform.position;
        tempMovement.y -= speed_Y * Time.deltaTime;
        transform.position = tempMovement;
    }

    void RotateMeteor()
    {
        z_Rotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(z_Rotation, Vector3.forward);

    }


}
