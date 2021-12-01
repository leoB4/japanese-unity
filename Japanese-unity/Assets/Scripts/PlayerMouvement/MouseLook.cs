using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivityX = 500f;
    public float mouseSensitivityY = 2500f;

    public float topAngleMax = -15f;
    public float botAngleMax = 5f;

    public Transform playerBody;

    private float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        xRotation -= mouseY / 100f;
        //             angle             top,  bottom
        xRotation = Mathf.Clamp(xRotation, topAngleMax, botAngleMax);
        
        transform.localRotation = Quaternion.Euler(xRotation,0,0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
