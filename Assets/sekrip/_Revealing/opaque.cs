using UnityEngine;

public class opaque : MonoBehaviour
{
    public Material mat;
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            Color newcolor = mat.color;
            newcolor.a = 0;
            mat.color = newcolor;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            Color newcolor = mat.color;
            newcolor.a = 1;
            mat.color = newcolor;
        }
    }
}
