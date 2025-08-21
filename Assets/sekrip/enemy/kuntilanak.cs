using UnityEngine;


public class kuntilanak : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform player;
    public float timer;
    public float speed;
    public GameObject mesh;
    public bool isChasing = false;
    private Rigidbody rb;
    private float timing;
    private Vector3 playerpos;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Random.Range(0, 100) <= 70)
        {
            mesh.transform.position = spawnPoint.position;
            playerpos = player.position;
            isChasing = true;
        }
    }

    void Start()
    {
        rb = mesh.GetComponent<Rigidbody>();
        timing = timer;
    }

    void Update()
    {
        if (isChasing)
        {
            chase();
            timing -= Time.deltaTime;
            if (timing <= 0)
            {
                isChasing = false;
                timing = timer;
            }
        }
    }

    void chase()
    {
        Vector3 dir = (playerpos - mesh.transform.position).normalized;
        rb.MovePosition(mesh.transform.position + dir * speed * Time.deltaTime);
    }
}
