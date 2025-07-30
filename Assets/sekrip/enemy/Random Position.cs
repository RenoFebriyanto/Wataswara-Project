using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomPosition : MonoBehaviour
{
    private NavMeshAgent AI;
    public Transform centerPoint;
    public float delayTime = 0.5f;
    private bool isWaiting = false;
    public float range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DelayMove());
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

}
