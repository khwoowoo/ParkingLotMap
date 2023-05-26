using UnityEngine;

public class ViewerController : MonoBehaviour
{
    private Vector2 touchStart;
    private Vector2 touchPrevious;
    public float moveSpeed = 0.1f;
    public float rotationSpeed = 0.5f;

    void Update()
    {
        // 터치 입력 처리
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // 터치 시작 시점
            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
                touchPrevious = touch.position;
            }
            // 터치 이동 중
            else if (touch.phase == TouchPhase.Moved)
            {
                // 이동 벡터 계산
                Vector2 touchDelta = touch.position - touchStart;
                Vector3 moveVector = new Vector3(-touchDelta.x, 0f, -touchDelta.y) * moveSpeed;
                transform.position += moveVector;

                // 회전
                float rotationDelta = touchDelta.x * rotationSpeed;
                transform.Rotate(Vector3.up, rotationDelta, Space.World);

                touchPrevious = touch.position;
            }
        }
    }
}
