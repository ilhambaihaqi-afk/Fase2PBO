using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;        // kecepatan jalan
    public float runSpeed = 6f;         // kecepatan lari
    public float rotationSpeed = 720f;  // kecepatan putar karakter

    private CharacterController controller;

    void Start()
    {
        // Pastikan Player punya CharacterController
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ambil input horizontal & vertical (WASD / panah)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v).normalized;

        // Pilih kecepatan, Shift = lari
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // Hitung movement
        Vector3 move = inputDir * speed;

        // Move character
        controller.Move(move * Time.deltaTime);

        // Rotasi menghadap arah gerak
        if (inputDir.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}