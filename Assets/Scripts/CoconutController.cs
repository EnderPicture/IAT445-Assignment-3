using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutController : MonoBehaviour
{
    public float landHeight;
    public float waterDrag;
    public float buoyancy;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.y < landHeight)
        {
            rigidbody.AddForce(new Vector3(0,buoyancy,0));
            rigidbody.drag = waterDrag;
        }
        else 
        {
            rigidbody.drag = 0;
        }
    }
}
