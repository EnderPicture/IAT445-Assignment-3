using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutController : MonoBehaviour
{
    public float landHeight;
    public float waterDrag;
    public float buoyancy;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.y < landHeight)
        {
            rb.AddForce(new Vector3(0,buoyancy,0));
            rb.drag = waterDrag;
        }
        else 
        {
            rb.drag = 0;
        }
    }
}
