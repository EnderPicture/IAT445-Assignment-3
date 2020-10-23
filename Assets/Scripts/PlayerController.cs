using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float range = 10f;
    public float power = 100f;

    public float coconutFirePower = 10;

    public GameObject coconut;
    public Transform firePosition;

    public Text text;

    public GameObject Music;
    GameObject musicPlayer;
    bool musicOn = false;


    public Text shellNumText;
    public Transform shellContainer;
    public GameObject dingSound;
    int numOfShellsTotal = 0;
    int numOfShells = 0;

    int numOfCoconut = 0;

    // Start is called before the first frame update
    void Start()
    {
        numOfShellsTotal = shellContainer.childCount;
        shellNumText.text = numOfShells + " / " + numOfShellsTotal;
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
        numOfCoconut++;
        text.text = numOfCoconut + "";
    }
    void CheckForward()
    {
        // https://docs.unity3d.com/Manual/Layers.html
        int layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, layerMask))
        {
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, hit.point, range);
            }
            if (hit.transform.tag == "Music")
            {
                if (musicOn)
                {
                    musicOn = false;
                    Destroy(musicPlayer);
                }
                else
                {
                    musicOn = true;
                    musicPlayer = Instantiate(Music, hit.transform.parent.position, Quaternion.Euler(0, 0, 0));
                }
            }
                Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "Shell")
            {
                Destroy(hit.transform.gameObject);
                numOfShells++;
                shellNumText.text = numOfShells + "/" + numOfShellsTotal;
                Instantiate(dingSound);
            }
        }

    }
}
