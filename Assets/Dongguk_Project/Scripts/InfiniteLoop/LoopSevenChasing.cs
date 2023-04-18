using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSevenChasing : MonoBehaviour
{
    private Animator anim;

    public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Player Entered");
            anim.Play("Loop7_Chasing");
        }
    }
}
