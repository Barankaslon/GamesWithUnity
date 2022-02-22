using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("MouseLook Sensivity")]
    [SerializeField] [Range(100f, 200f)] private float mouseSesivityXAxis = 150f;
    [SerializeField] [Range(100f, 200f)] private float mouseSesivityYAxis = 130f;

    [SerializeField] private Transform playerControllerTransform;
    [SerializeField] private Transform cameraTransform;

    [Header("Camera X Rotation")]
    [SerializeField] [Range(-60f, -40f)] private float minCameraXRotationAngle = -50f;
    [SerializeField] [Range(40f, 60f)] private float maxCameraXRotationAngle = 50f;

    private Vector2 inputValue;
    private Vector3 tempAngles = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() 
    {
        GetPlayerInput();
        LookAtX();
        LookAtY();
    }

    void LookAtX()
    {
        playerControllerTransform.Rotate(new Vector3(0f, inputValue.x, 0f));
    }

    void LookAtY()
    {
        tempAngles.x -= inputValue.y;
        tempAngles.x = Mathf.Clamp(tempAngles.x, minCameraXRotationAngle, maxCameraXRotationAngle);
        cameraTransform.localRotation = Quaternion.Euler(tempAngles);
    }

    void GetPlayerInput()
    {
        float mouseXInput = Input.GetAxis(TagManager.MOUSE_X) * mouseSesivityXAxis * Time.deltaTime;
        float mouseYInput = Input.GetAxis(TagManager.MOUSE_Y) * mouseSesivityYAxis * Time.deltaTime;

        inputValue = new Vector2(mouseXInput, mouseYInput);
    }
}
