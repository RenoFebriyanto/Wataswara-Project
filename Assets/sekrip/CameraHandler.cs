using UnityEngine;
using UnityEngine.InputSystem;

public class CameraHandler : MonoBehaviour
{
    [Header("refferences")]
    public Transform orientation;
    public Transform playermesh;
    public Transform player;
    public InputActionReference move;
    public CharacterController controller;

    private float rotationSpd = 10f;

    void Start()
    {
        move.action.Enable();
    }
    void Update()
    {
        Vector3 viewdir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewdir.normalized;

        //rotation
        Vector2 input = move.action.ReadValue<Vector2>();
        Vector3 inputdir = orientation.forward * input.y + orientation.right * input.x;

        if (inputdir != Vector3.zero)
        {
            playermesh.forward = Vector3.Slerp(playermesh.forward, inputdir.normalized, Time.deltaTime * rotationSpd);
        }
    }
}
