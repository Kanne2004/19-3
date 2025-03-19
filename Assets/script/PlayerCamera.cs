using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Độ nhạy chuột
    public Transform playerBody;  // Body nhân vật (để xoay thân nhân vật)
    public float verticalRotationLimit = 80f;  // Giới hạn quay theo chiều dọc (lên xuống)

    private float xRotation = 0f;  // Góc quay theo trục x (lên xuống)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Ẩn và khóa chuột
        Cursor.visible = false;
    }

    void Update()
    {
        // Lấy giá trị di chuyển chuột (x: trái/phải, y: lên/xuống)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Xoay camera theo chiều ngang (trục y)
        transform.Rotate(Vector3.up * mouseX);

        // Cập nhật góc quay theo chiều dọc (trục x), giới hạn theo chiều dọc
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalRotationLimit, verticalRotationLimit);  // Giới hạn góc quay theo chiều dọc
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Xoay thân nhân vật theo trục y (như thể xoay nhân vật)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
