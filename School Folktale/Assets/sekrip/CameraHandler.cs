using UnityEngine;
using UnityEngine.InputSystem;

public class CameraHandler : MonoBehaviour
{
    [Header("refferences")]
    public Transform orientation, player, playerobj;
    public CharacterController controller;

    public float rotationSpeed;

    [SerializeField]
    private InputActionReference keyboard;
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
{
    Vector2 input = keyboard.action.ReadValue<Vector2>();

    // Hitung arah input relatif ke kamera
    Vector3 inputDir = orientation.forward * input.y + orientation.right * input.x;

    // Update orientation agar selalu mengikuti kamera (boleh terus)
    Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
    orientation.forward = viewDir.normalized;

    // Hanya rotasi kalau input keyboard ditekan
    if (inputDir != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(inputDir.normalized);
        player.rotation = Quaternion.RotateTowards(player.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}


}