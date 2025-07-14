using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class kuntilanak : MonoBehaviour
{
    public Transform kunti;
    public Transform player;
    private float gravitation = -30.81f;
    private Vector3 velocity;
    public CharacterController kontroler;
    public Vector3 location;
    public float speed = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        CharacterController cc = kunti.GetComponent<CharacterController>();
        cc.enabled = false; // disable temporarily to warp
        kunti.position = location;
        cc.enabled = true; // re-enable
        Debug.Log("Kunti teleported.");
        }
    }
    void Awake()
    {
        location = new Vector3(transform.position.x,transform.position.y+10,transform.position.z);
    }

    void Update()
    {
        if (kontroler.isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravitation * Time.deltaTime;
            Debug.Log(velocity.y);
        }
        kontroler.Move(velocity * Time.deltaTime);
    }
}
