using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public float moveSpeed, distance_Factor = 1f;
    private float distance_Move;
    private bool gameJustStarted;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        gameJustStarted = true;
    }

    void Update()
    {
        MoveCamera();
    }


    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    void MoveCamera()
    {
        if(gameJustStarted)
        {
            //check if player is alive
            if(moveSpeed < 12.0f)
            {
                moveSpeed += Time.deltaTime * 5.0f;
            }
            else
            {
                moveSpeed = 12.0f;
                gameJustStarted = false;
            }

        }

        //check if player is alive
        Camera.main.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

    }

    void UpdateDistance()
    {
        distance_Move += Time.deltaTime * distance_Factor;
        float round = Mathf.Round(distance_Move);

        //Count and show the score

        if(round >= 30.0f && round < 60.0f)
        {
            moveSpeed = 14f;
        }
        else if(round >= 60.0f)
        {
            moveSpeed = 16f;
        }
    }
}
