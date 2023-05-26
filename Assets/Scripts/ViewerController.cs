using UnityEngine;

public class ViewerController : MonoBehaviour
{
    private Vector2 touchStart;
    private Vector2 touchPrevious;
    public float moveSpeed = 0.1f;
    public float rotationSpeed = 0.5f;

    void Update()
    {
        // ��ġ �Է� ó��
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // ��ġ ���� ����
            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
                touchPrevious = touch.position;
            }
            // ��ġ �̵� ��
            else if (touch.phase == TouchPhase.Moved)
            {
                // �̵� ���� ���
                Vector2 touchDelta = touch.position - touchStart;
                Vector3 moveVector = new Vector3(-touchDelta.x, 0f, -touchDelta.y) * moveSpeed;
                transform.position += moveVector;

                // ȸ��
                float rotationDelta = touchDelta.x * rotationSpeed;
                transform.Rotate(Vector3.up, rotationDelta, Space.World);

                touchPrevious = touch.position;
            }
        }
    }
}
