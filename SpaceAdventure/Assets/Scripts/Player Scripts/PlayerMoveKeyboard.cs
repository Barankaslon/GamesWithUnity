using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    [SerializeField] public float speed = 600f;

    private Rigidbody2D _myBody;

    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    private  void FixedUpdate() 
    {
        HandleMovement();
    }

    void HandleMovement()
    {

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _myBody.AddForce(transform.up * speed);
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _myBody.AddForce(-transform.up * speed);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _myBody.AddForce(transform.right * speed);
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _myBody.AddForce(-transform.right * speed);
        }
    }

    
    
    

}
