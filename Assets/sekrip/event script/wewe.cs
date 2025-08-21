using UnityEngine;

public class wewe : MonoBehaviour
{
    public int chance;

    public int Rand()
    {
        int value = Random.Range(0, 100);
        return value;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Rand()<chance)
            {
                
            }
        }
    }
}
