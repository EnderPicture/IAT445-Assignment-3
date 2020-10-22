using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBlob : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 initPos;
    Vector3 initRot;

    void Start()
    {
        initPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        initRot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        // makes the boat go up and down
        Vector3 position = new Vector3(
            initPos.x,
            initPos.y + Mathf.Sin(Time.realtimeSinceStartup/2)/5, 
            initPos.z);
        transform.position = position;
        
        Vector3 rotation = new Vector3(
            initRot.x + Mathf.Sin(Time.realtimeSinceStartup/2.5f),
            initRot.y + Mathf.Sin(Time.realtimeSinceStartup/3f),
            initRot.z + Mathf.Sin(Time.realtimeSinceStartup/3.5f));
        transform.rotation = Quaternion.Euler(rotation);
    }
}
