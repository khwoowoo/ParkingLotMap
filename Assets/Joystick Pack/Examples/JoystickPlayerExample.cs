using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;


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
