using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    public int Rand(int max)
    {
        int value = Random.Range(0, max);
        return value;
    }
}
