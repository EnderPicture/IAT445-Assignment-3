using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrassGen : MonoBehaviour
{
    // Start is called before the first frame update
    // This script is to combat the inability to paint grass or trees without a terrain object
    // only used once to generate grass then make static
    public GameObject tallGrass;
    private void Start() {
        Mesh grassMesh = GetComponent<MeshFilter>().mesh;
        
        Vector3[] vertices = grassMesh.vertices;
        Vector3[] normals = grassMesh.normals;
        for (int c = 0; c < 20; c++ ) {
            int index = Random.Range(0, vertices.Length);
            Vector3 vertex = vertices[index];
            Vector3 normal = normals[index];

            Vector3 axisZ = normal;
            Vector3 axisX = new Vector3();
            Vector3 axisY = new Vector3();
            Vector3.OrthoNormalize(ref axisZ, ref axisX, ref axisY);
            
            for (int i = 0; i < 10; i++) {
                float randomX = Random.Range(-1f,1f);
                float randomY = Random.Range(-1f,1f);
                
                GameObject newGrass = Instantiate(tallGrass,vertex+axisX*randomX+axisY*randomY-normal*.1f,
                    Quaternion.Euler(Random.Range(-10f,10f),Random.Range(0f,360f),Random.Range(-10f,10f)));
                newGrass.transform.parent = transform;
                Vector3 scale = newGrass.transform.localScale;
                newGrass.transform.localScale = scale + new Vector3(Random.Range(-.1f,.1f),Random.Range(-.1f,.1f),Random.Range(-.1f,.1f));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
