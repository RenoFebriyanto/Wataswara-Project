using UnityEngine;
using UnityEngine.AI;

public class genderuwo : MonoBehaviour
{
    //refferencing Agent
    [SerializeField] NavMeshAgent Ai;
    //a series of path the AI will goes on. 
    [SerializeField] Transform[] walkPoints;
    //boolean to check the condition
    bool atStart;
    //Int to check the current index
    private int currentIndex = 0;

    //put the destination inside a parent that have mesh as it's children. so it looks orginized. and it will look like Genderuwo object(Parent) have a child. which is it's mesh (Body) and his walk path



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ai = GetComponent<NavMeshAgent>();
        if (walkPoints.Length > 0)
        {    
        Ai.SetDestination(walkPoints[currentIndex].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ai.pathPending && Ai.remainingDistance < 0.5f)
        {
            // Move to next point
            if (atStart)
            {
                currentIndex++;
                if (currentIndex >= walkPoints.Length)
                {
                    currentIndex = walkPoints.Length - 1;
                    atStart = false;
                }
            }
            else
            {
                currentIndex--;
                if (currentIndex < 0)
                {
                    currentIndex = 0;
                    atStart = true;
                }
            }

            Ai.SetDestination(walkPoints[currentIndex].position);
        }
    }
}
