    using UnityEngine;

    public class reveal1 : MonoBehaviour
    {
        public Light spotlight;
        public MeshRenderer body;

        private float targetAlpha = 0f;
        private float currentAlpha = 0f;
        private Color baseColor;

        private bool revealedByTrigger = false;

        void Start()
        {
            baseColor = body.material.color;

            // Setup transparency properly
            Material mat = body.material;
            mat.SetOverrideTag("RenderType", "Transparent");
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;

            Color invisible = baseColor;
            invisible.a = 0f;
            mat.color = invisible;
        }

        void Update()
        {
            bool inLightCone = false;

            if (spotlight != null && spotlight.enabled)
            {
                Vector3 toTarget = (transform.position - spotlight.transform.position).normalized;
                float angle = Vector3.Angle(spotlight.transform.forward, toTarget);
                float distance = Vector3.Distance(spotlight.transform.position, transform.position);

                if (angle < spotlight.spotAngle * 0.5f && distance < spotlight.range)
                {
                    Ray ray = new Ray(spotlight.transform.position, toTarget);
                    if (Physics.Raycast(ray, out RaycastHit hit, spotlight.range))
                    {
                        if (hit.transform == transform)
                        {
                            inLightCone = true;
                        }
                    }
                }
            }

            targetAlpha = (inLightCone || revealedByTrigger) ? 1f : 0f;

            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * 15);
            Color newColor = baseColor;
            newColor.a = currentAlpha;
            body.material.color = newColor;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Light"))
            {
                revealedByTrigger = true;
            }
            Debug.Log("Revealll");
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Light"))
            {
                revealedByTrigger = false;
            }
            Debug.Log("Dis appear");
        }
    }
