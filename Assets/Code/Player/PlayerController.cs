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
    public GameObject camera;
    public Camera cam;

    [Header("Strong Dependencies")]
    public float moveSpeed = 7f;
    public float jumpHeight = 10f;

    // Inner variables
    private float xRotation = 0f;
    protected Vector3 velocity = Vector3.zero;

    // Outer variables
    public Vector3 Velocity
    { 
        get
        {
            return new Vector3(velocity.x, velocity.y / Time.deltaTime, velocity.z);
        }
    }

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

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = (transform.right * x + transform.forward * z) * (Time.deltaTime * moveSpeed);
        controller.Move(move);
    }
}
