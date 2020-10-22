using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Animator dishAnimator;

    public GameObject WarningSound;
    GameObject spawnedSound;
    public float stopDelay;
    float timeReleased = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > timeReleased + stopDelay)
        {
            animator.SetBool("goDown", false);
            dishAnimator.SetBool("goDown", false);
            Destroy(spawnedSound);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            animator.SetBool("goDown", true);
            dishAnimator.SetBool("goDown", true);
            Destroy(spawnedSound);
            spawnedSound = Instantiate(WarningSound, transform.position, transform.rotation);
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player")
        {
            timeReleased = Time.realtimeSinceStartup;
        }
    }
}
