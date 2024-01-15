using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            animator.SetTrigger("Attacking");
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            animator.SetTrigger("Death");
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            //Make sure to set speed to one so it actually plays after you turned it off
            animator.SetFloat("WalkSpeed", 1);
            animator.Play("Walk");       
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            animator.SetFloat("WalkSpeed", 0);
        }
    }
}
