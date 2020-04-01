using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu(" BeHive/Player/Player Controller", 1)]
public class PlayerController : MonoBehaviour
{
    [Header("Strong Dependencies")]
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private GameObject camera;
    private Camera cam;

    // Inner variables
    private float xRotation = 0f;
    public void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = camera.GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -Rules.CameraClamp, Rules.CameraClamp);

        transform.Rotate(Vector3.up * mouseX);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
