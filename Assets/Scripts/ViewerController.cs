using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 2.0f;

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    public GameObject exitUI;

    void Start()
    {
    }

    void Update()
    {
        // WASD 이동
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        // 마우스 회전
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitUI.SetActive(true);
        }
    }
}
