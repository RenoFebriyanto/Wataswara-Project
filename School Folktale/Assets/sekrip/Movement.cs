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
    gravitation = -9.81f;

    [SerializeField]
    private bool gravity;

    private Vector3 velocity;

    [SerializeField]
    private Transform orientation;
    private Vector3 movedirection;

    [SerializeField]
    private Animator anim;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = _movementinput.action.ReadValue<Vector2>();
        movementhandle(input);
        Debug.Log(anim);

        if (input.x != 0 || input.y != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

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
        movedirection = orientation.forward * input.y + orientation.right * input.x;
        controller.Move(movedirection.normalized * speed * Time.deltaTime);
    }

    private void gravityhandler()
    {
        controller.Move(velocity * Time.deltaTime);
    }
}

