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
    void Update()
    {
        
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        Vector2 input = keyboard.action.ReadValue<Vector2>();
        Debug.Log("Input: " + input); // <- this should print values like (0, 1) when you press W
        Vector3 inputdir = orientation.forward * input.y + orientation.right * input.x;

        if (inputdir != Vector3.zero)
        {
            playerobj.forward = Vector3.Slerp(playerobj.forward, inputdir.normalized, Time.deltaTime * rotationSpeed); 
        }
    }
}
