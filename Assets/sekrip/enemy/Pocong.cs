using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Pocong : MonoBehaviour
{
    private NavMeshAgent AI;
    public float range;
    public Transform centerPoint;
    public float delayTime = 0.5f;
    private bool isWaiting = false;
    public Transform player;
    Vector3 dest;
    public float aispeed, catchDistance, jumpscareTime;
    public Light spotlight;

    private Coroutine waitCoroutine = null;

    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
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

        if (!inLightCone && waitCoroutine != null   )
        {
            StopCoroutine(waitCoroutine);
            waitCoroutine = null;
            AI.isStopped = false; // Resume movement if flashlight gone
        }

        if (!isWaiting && AI.remainingDistance <= AI.stoppingDistance && !AI.pathPending && waitCoroutine == null)
        {
            StartCoroutine(DelayMove());
        }
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
        yield return new WaitForSeconds(1.5f);
        jumpscare();
    }

    void jumpscare()
    {
        Debug.Log("💀 Jumpscare triggered by Pocong!");
        // implement camera switch, game over, scream, etc.
    }
}
