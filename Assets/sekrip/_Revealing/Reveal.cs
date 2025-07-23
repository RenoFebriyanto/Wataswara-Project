//Shady
using UnityEngine;

[ExecuteInEditMode]
public class Reveal : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;
	
	void Update ()
    {
    if (!Mat || !SpotLight) return;

    if (SpotLight.enabled)
    {
        Mat.SetVector("_LightPosition", SpotLight.transform.position);
        Mat.SetVector("_LightDirection", -SpotLight.transform.forward);
        Mat.SetFloat("_LightAngle", SpotLight.spotAngle);
    }
    else
    {
        Mat.SetFloat("_LightAngle", 0);
        Mat.SetVector("_LightDirection", Vector3.zero);
        Mat.SetVector("_LightPosition", Vector3.one * 9999);
    }
    }//Update() end
}//class end