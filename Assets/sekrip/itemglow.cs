using UnityEngine;

public class itemglow : MonoBehaviour
{
    public Material mats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("MASUKKKK");
        if (other.CompareTag("Flashlight"))
        {
            mats.SetFloat("_scale", 1.3f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("KELUARRRRR");
        if (other.CompareTag("Flashlight"))
        {
            mats.SetFloat("_scale", 0f);
        }
    }
}
