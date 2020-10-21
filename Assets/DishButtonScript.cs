using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Animator dishAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.transform.name);
        if (other.transform.tag == "Player") {
            animator.SetBool("goDown", true);
            dishAnimator.SetBool("goDown", true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Player") {
            animator.SetBool("goDown", false);
            dishAnimator.SetBool("goDown", false);
        }
    }
}
