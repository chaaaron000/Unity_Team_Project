using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSevenChasing : MonoBehaviour
{
    private Animator anim;

    public GameObject ghost;
    private GhostAnimation ghostAnim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ghostAnim = ghost.GetComponent<GhostAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ghostAnim.IsPlayerTouched())
        {
            anim.enabled = false;
        }
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
