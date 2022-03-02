using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    private enum BlockState
    {
        Fall,
        Reset,
        Idle
    }

    private BlockState blockState = BlockState.Idle;

    private float fallTime;

    [SerializeField] private float fallDistance = 3.5f;
    [SerializeField] private float fallPower = 6f;
    [SerializeField] private float idleDuration = 1f;
    [SerializeField] private float resetDuration = 2f;
    [SerializeField] private float minIdleDuration = 1f, maxIdleDuration = 2f;

    private Vector3 startPos, endPos;

    private void Start() 
    {
        startPos = transform.position;
        endPos = transform.position - new Vector3(0f, fallDistance);
    }

    private void Update() {
        {
            switch (blockState)
            {
                case BlockState.Fall:

                    fallTime += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPos, endPos, Mathf.Pow(fallTime, fallPower));

                    if(transform.position == endPos)
                    {
                        blockState = BlockState.Reset;
                        fallTime = 0f;
                    }
                    break;
                case BlockState.Reset:

                    fallTime += Time.deltaTime / resetDuration;
                    transform.position = Vector3.Lerp(endPos, startPos, fallTime);

                    if(transform.position == startPos)
                    {
                        blockState = BlockState.Idle;
                        fallTime = 0f;
                    }
                    break;
                case BlockState.Idle:

                    fallTime += Time.deltaTime;

                    if(fallTime > idleDuration)
                    {
                        idleDuration = Random.Range(minIdleDuration, maxIdleDuration);
                        blockState = BlockState.Fall;
                        fallTime = 0f;
                    }
                    break;
            }
        }
    }
}
