using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float range = 10f;
    public float power = 100f;

    public float coconutFirePower = 10;

    public GameObject coconut;
    public Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // https://www.youtube.com/watch?v=THnivyG0Mvo
        if (Input.GetButtonDown("Fire1"))
        {
            CheckForward();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            CoconutFire();
        }
    }
    void CoconutFire()
    {
        GameObject newCoconut = Instantiate(coconut, firePosition.position, Quaternion.Euler(firePosition.forward));
        newCoconut.GetComponent<Rigidbody>().AddForce(firePosition.forward * coconutFirePower, ForceMode.Impulse);
    }
    void CheckForward()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, hit.point, range);
            }
        }

    }
}
