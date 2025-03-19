using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Tốc độ di chuyển

    void Update()
    {
        // Lấy input từ các phím W, A, S, D
        float moveX = Input.GetAxis("Horizontal");  // A/D hoặc phím mũi tên trái/phải
        float moveZ = Input.GetAxis("Vertical");    // W/S hoặc phím mũi tên lên/xuống

        // Tạo vector di chuyển
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;

        // Di chuyển nhân vật
        transform.Translate(movement);
    }
}
