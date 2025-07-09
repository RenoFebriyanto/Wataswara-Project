using System.Collections;
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
        if (_runinput.action.IsPressed())
        {
            speedcap = 5f;
            Debug.Log("running");
        }
        else
        {
            speedcap = 3f;
        }
    }

    private void movementhandle(Vector2 input)
    {
        movedirection = orientation.forward * input.y + orientation.right * input.x;
        if (input != Vector2.zero && speed<speedcap)
        {
            StartCoroutine(speedup());
        }
        if (input == Vector2.zero)
        {
            speed = 1f;
        }
        controller.Move(movedirection.normalized * speed * Time.deltaTime);
        Debug.Log(speed);
    }

    private void gravityhandler()
    {
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator speedup()
    {
        while (speed < speedcap)
        {
            speed += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        while (speed > speedcap)
        {
            speed -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

