using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomPosition : MonoBehaviour
{
    private NavMeshAgent AI;
    public Transform centerPoint;
    public float range;
    private bool waiting;

    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (AI.remainingDistance <= AI.stoppingDistance && !waiting)
        {
            Vector3 point;
            if (RandomPoint(centerPoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); // for debug
                AI.SetDestination(point);
            }

            waiting = true;
            StartCoroutine(wait());
        }
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

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        waiting = false;
    }
}
