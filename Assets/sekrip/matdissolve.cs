using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class matdissolve : MonoBehaviour
{
    public Material mat;
    public float slider =1;
    void Start()
    {
        mat = GetComponent<Image>().material;
    }
    void Update()
    {
        mat.SetFloat("_blood_width",slider);
    }
    void OnEnable()
    {

    }
}
