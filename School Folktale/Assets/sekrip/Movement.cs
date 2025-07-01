using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private InputActionReference
    _movementinput;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float speed = 5f,
    gravitation = -9.81f,
    rotationSpeed = 10f;

    private float currentYRotation = 0f;

    [SerializeField]
    private bool gravity;

    private Vector3 velocity;

    void Awake()
    {
        controller.GetComponent<CharacterController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = _movementinput.action.ReadValue<Vector2>();
        movementhandle(input);

        if (gravity)
        {
            gravityhandler();
        }

        if (controller.isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravitation * Time.deltaTime;
        }



    }

    private void movementhandle(Vector2 input)
    {
        Vector3 move = new Vector3(input.x, 0f, input.y);
        move = transform.TransformDirection(move);
        controller.Move(move * speed * Time.deltaTime);
    }

    private void gravityhandler()
    {
        controller.Move(velocity * Time.deltaTime);
    }

    // private void bodyrotation(Vector2 input)
    // {
    //     float sens = input.x * rotationSpeed * Time.deltaTime;
    //     transform.Rotate(Vector3.up * sens);
    // }
}

