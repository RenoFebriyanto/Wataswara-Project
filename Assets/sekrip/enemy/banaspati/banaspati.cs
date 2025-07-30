using UnityEngine;
using UnityEngine.AI;

public class banaspati : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent AI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AI.remainingDistance >0.5)
        {
            anim.stop
        }
    }
}
