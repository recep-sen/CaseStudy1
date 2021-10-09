//A simple script to open or close lights
using UnityEngine;

public class ToggleLİghts : MonoBehaviour
{
    public GameObject[] Lights;
    public GameObject[] LightMaterials;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            foreach (GameObject lights in Lights)
            {
                lights.SetActive((!lights.activeInHierarchy));
            }
            foreach (GameObject material in LightMaterials)
            {
                if (material.GetComponent<Renderer>().material.IsKeywordEnabled("_EMISSION"))
                {
                    material.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                }
                else
                {
                    material.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                }
            }
        }
    }
}