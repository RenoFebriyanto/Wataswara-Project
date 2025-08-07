using UnityEngine;

public class RandomEvent : MonoBehaviour
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
                Debug.Log("DUAR");
            }
        }
    }
}
