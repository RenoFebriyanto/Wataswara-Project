    using UnityEngine;

    public class reveal1 : MonoBehaviour
{
    private Material mat;
    public void SetVisible(bool value)
    {
        mat.SetFloat("_Visible", value ? 1f : 0f);
    }
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            Debug.Log("seharusnya visible");
            SetVisible(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            SetVisible(false);
        }
    }
}
