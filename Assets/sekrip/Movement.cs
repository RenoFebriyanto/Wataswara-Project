
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private InputActionReference
    _movementinput,
    _runinput;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float speedcap = 3f,
    gravitation = -9.81f;
    private float speed = 1f;

    [SerializeField]
    private bool gravity;

    private Vector3 velocity;

    [SerializeField]
    private Transform orientation;
    private Vector3 movedirection;
    public float stamina = 500f;

    [SerializeField]
    private Animator anim;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        _movementinput.action.Enable();
        _runinput.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 input = _movementinput.action.ReadValue<Vector2>();
        movementhandle(input);
        animcontrol();
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

        //sprint code
        if (_runinput.action.IsPressed() && stamina > 0 && input != Vector2.zero)
        {
            speedcap = 5f;
            if (stamina <= 250)
            {
                stamina -= 50f * Time.deltaTime;
            }
            else
            {
                stamina -= 25f * Time.deltaTime;
            }
        }
        else
        {
            speedcap = 3f;
            stamina += 25f * Time.deltaTime;
        }
        stamina = Mathf.Clamp(stamina, 0, 500);
    }

    private void movementhandle(Vector2 input)
    {
        movedirection = orientation.forward * input.y + orientation.right * input.x;
        if (input == Vector2.zero)
        {
            speed = 1f;
        }
        else
        {
            speed = Mathf.Lerp(speed, speedcap, Time.deltaTime * 3f);
        }
        controller.Move(movedirection.normalized * speed * Time.deltaTime);
    }

    private void gravityhandler()
    {
        controller.Move(velocity * Time.deltaTime);
    }

    void animcontrol()
    {
        anim.SetFloat("MoveSpeed", speed);
    } 
}

