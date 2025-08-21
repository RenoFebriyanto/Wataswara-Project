using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.Cinemachine;

public class Pocong : MonoBehaviour
{
    private NavMeshAgent AI;
    public float range;
    public Transform centerPoint;
    public float delayTime = 0.5f;
    private bool isWaiting = false;
    public Light spotlight;

    private Coroutine waitCoroutine = null;
    private Animator anim;
    private AudioSource audio;
    public CinemachineCamera Jumpscarecam;

    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
        
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 toTarget = (transform.position - spotlight.transform.position).normalized;
        float angle = Vector3.Angle(spotlight.transform.forward, toTarget);
        float distance = Vector3.Distance(spotlight.transform.position, transform.position);

        bool inLightCone = false;

        if (angle < spotlight.spotAngle * 0.5f && distance < spotlight.range)
        {
            Ray ray = new Ray(spotlight.transform.position, toTarget);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, spotlight.range))
            {
                Debug.DrawRay(spotlight.transform.position, toTarget);
                if (hit.transform == this.transform)
                {
                    inLightCone = true;
                }
            }
        }

        if (inLightCone && waitCoroutine == null && spotlight.enabled)
        {
            waitCoroutine = StartCoroutine(WaitForJumpscare());
        }

        if (!isWaiting && AI.remainingDistance <= AI.stoppingDistance && !AI.pathPending && waitCoroutine == null)
        {
            StartCoroutine(DelayMove());
        }

        if (AI.remainingDistance <= AI.stoppingDistance || AI.isStopped)
        {
            anim.SetBool("Iswalk", false);
        }
        else
        {
            anim.SetBool("Iswalk", true);
        }
        Debug.Log(waitCoroutine);
    }

    IEnumerator DelayMove()
    {
        isWaiting = true;
        yield return new WaitForSeconds(delayTime);

        Vector3 point;
        if (RandomPoint(centerPoint.position, range, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            AI.SetDestination(point);
        }

        isWaiting = false;
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    IEnumerator WaitForJumpscare()
    {
        AI.isStopped = true;
        yield return new WaitForSeconds(2f);
        jumpscare();
    }

    void jumpscare()
    {
        Debug.Log("💀 Jumpscare triggered by Pocong!");
        // implement camera switch, game over, scream, etc.
        Jumpscarecam.Priority = 10;
        audio.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            if (spotlight.enabled && waitCoroutine == null)
            {
                waitCoroutine = StartCoroutine(WaitForJumpscare());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("IM EXITING BITCH");
        if (other.CompareTag("Flashlight"))
        {
            if (waitCoroutine != null)
            {
                StopCoroutine(waitCoroutine);
                waitCoroutine = null;
                AI.isStopped = false;
            }
        }
    }

        // void OnTriggerStay(Collider other)
        // {
        //         Debug.Log(other.tag);
        //     if (other.CompareTag("Flashlight"))
        //     {
        //         Debug.Log("inflash");
        //         if (spotlight.enabled && waitCoroutine == null)
        //         {
        //             waitCoroutine = StartCoroutine(WaitForJumpscare());
        //         }
        //     }
        // }
}
