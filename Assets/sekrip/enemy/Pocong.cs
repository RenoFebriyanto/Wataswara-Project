using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Pocong : MonoBehaviour
{
    private NavMeshAgent AI;
    public float range;
    public Transform centerPoint;
    public float delayTime = 0.5f; // ⏱️ Delay in seconds
    private bool isWaiting = false;

    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Only move if not already waiting AND has reached destination
        if (!isWaiting && AI.remainingDistance <= AI.stoppingDistance && !AI.pathPending)
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
}
