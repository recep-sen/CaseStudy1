using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFinder : MonoBehaviour
{
    public Material testmaterial;
    Material[] duplicatematerials;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int layermask = 1 << 3;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit,layermask))
            {
                Mesh m = GetMesh(hit.collider.gameObject);
                if (m)
                {
                    int[] hittedTriangle = new int[]
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
                            if (subMeshTris[j] == hittedTriangle[0] &&
                                subMeshTris[j + 1] == hittedTriangle[1] &&
                                subMeshTris[j + 2] == hittedTriangle[2])
                            {
                                Debug.Log(string.Format("triangle index:{0} submesh index:{1} submesh triangle index:{2}", hit.triangleIndex, i, j / 3));
                                //Material material = hit.collider.GetComponent<MeshRenderer>().sharedMaterials[i];
                                duplicatematerials = hit.collider.GetComponent<MeshRenderer>().sharedMaterials;
                                duplicatematerials[i] = testmaterial;
                                hit.collider.GetComponent<MeshRenderer>().sharedMaterials = duplicatematerials;
                                //material = testmaterial;
                                //Debug.Log(material);
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
}