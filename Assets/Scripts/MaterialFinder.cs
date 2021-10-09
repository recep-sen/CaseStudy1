//A script to find the material where camera is pointing and also 2 methods to change color and texture of the said material. They are being called globally from UI scripts.

using UnityEngine;
using UnityEngine.UI;

public class MaterialFinder : MonoBehaviour
{
    public static Material[] duplicateMaterials;
    public static int targetMaterialIndex;
    public GameObject targetText;
    public static GameObject targetObject;
    public GameObject crosshair;
    void FixedUpdate()
    {
        //need to check layermask before raycasting because player object has a collider
        int layermask = 1 << 3;

        //raycast to find hit point where camera is pointing
        if (crosshair.activeInHierarchy)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layermask))
            {
                targetObject = hit.collider.gameObject;

                //because there are objects with more than one material, need to check within submeshes to get an array with materials and index of which material camera is pointing
                Mesh m = GetMesh(hit.collider.gameObject);
                if (m)

                {
                    int[] hitTriangle = new int[]
                    {
                        m.triangles[hit.triangleIndex * 3],
                        m.triangles[hit.triangleIndex * 3 + 1],
                        m.triangles[hit.triangleIndex * 3 + 2]
                    };
                    for (int i = 0; i < m.subMeshCount; i++)
                    {
                        int[] subMeshTris = m.GetTriangles(i);
                        for (int j = 0; j < subMeshTris.Length; j += 3)
                        {
                            if (subMeshTris[j] == hitTriangle[0] &&
                                subMeshTris[j + 1] == hitTriangle[1] &&
                                subMeshTris[j + 2] == hitTriangle[2])
                            {
                                //Because unity doesnt allow changing materials directly, need to store materials in a duplicate array
                                duplicateMaterials = hit.collider.GetComponent<MeshRenderer>().sharedMaterials;
                                targetText.GetComponent<Text>().text = duplicateMaterials[i].name;
                            }
                        }
                    }
                }

            }
        }
        
        static Mesh GetMesh(GameObject go)
        {
            if (go)
            {
                MeshFilter mf = go.GetComponent<MeshFilter>();
                if (mf)
                {
                    Mesh m = mf.sharedMesh;
                    if (!m) { m = mf.mesh; }
                    if (m)
                    {
                        return m;
                    }
                }
            }
            return (Mesh)null;
        }

    }

    public static void ChangeColor(Color color)
    {
        /**method that changes color to color from UI*/
        duplicateMaterials[targetMaterialIndex].color = color;

    }

    public static void ChangeTexture(Texture texture)
    {
        /**method that changes texture to texture from UI*/
        duplicateMaterials[targetMaterialIndex].mainTexture = texture;

    }
}