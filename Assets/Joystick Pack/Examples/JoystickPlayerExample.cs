using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public Scrollbar scrollbar;
    public float scrollSpeed = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    private void Update()
    {
        float scrollValue = scrollbar.value; // 스크롤 UI의 값을 가져옴

        // 오브젝트의 새로운 위치를 계산
        float targetY = Mathf.Lerp(minY, maxY, scrollValue);

        // 새로운 위치로 오브젝트를 이동
        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.left * variableJoystick.Vertical + Vector3.forward * variableJoystick.Horizontal;
        Vector3 targetVelocity = direction * speed;

        // 현재 속도가 제한 값을 초과하지 않는 경우에만 목표 속도로 설정
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.velocity = targetVelocity;
        }
    }
}
