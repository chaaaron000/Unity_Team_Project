using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimation : MonoBehaviour
{
    private Animator anim;

    private bool touched = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Player Entered");
        if (CheckPlayer(other))
        {
            // anim.enabled = false;
            gameObject.GetComponent<Transform>().Rotate(-90.0f, 0, 0);
            gameObject.GetComponent<Transform>().Translate(0, 0, 1.15f);
            // anim.enabled = true;
            anim.Play("attack_3");
            touched = true;
        }
    }

    bool CheckPlayer(Collider other)
    {
        // Debug.Log("Check Player");
        if (other.CompareTag("Player"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsPlayerTouched()
    {
        return touched;
    }

}
