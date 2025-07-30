using UnityEngine;

public class reveal1 : MonoBehaviour
{
    public Light spotlight;
    public MeshRenderer body;

    private float targetAlpha = 0f;
    private float currentAlpha = 0f;
    private Color baseColor;

    void Start()
    {
        baseColor = body.material.color;

        // Make sure material is using transparency
        body.material.SetFloat("_Mode", 3);
        body.material.EnableKeyword("_ALPHABLEND_ON");
        body.material.renderQueue = 3000;

        Color invisible = baseColor;
        invisible.a = 0f;
        body.material.color = invisible;
    }

    void Update()
    {
        Vector3 toTarget = (transform.position - spotlight.transform.position).normalized;
        float angle = Vector3.Angle(spotlight.transform.forward, toTarget);
        float distance = Vector3.Distance(spotlight.transform.position, transform.position);

        bool inLightCone = false;

        if (angle < spotlight.spotAngle * 0.5f && distance < spotlight.range)
        {
            Ray ray = new Ray(spotlight.transform.position, toTarget);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, spotlight.range))
            {
                if (hit.transform == transform)
                {
                    inLightCone = true;
                }
            }
        }
        if (spotlight.enabled)
        {
            // Move this outside, so it still fades out when NOT lit
            targetAlpha = inLightCone ? 1f : 0f;
            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * 15);

            Color newColor = baseColor;
            newColor.a = currentAlpha;
            body.material.color = newColor;
        }
    }
}
