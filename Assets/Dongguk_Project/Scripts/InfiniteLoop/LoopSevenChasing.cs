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
            anim.Play("Loop7_Chasing");
            other.GetComponent<CustomSimplePlayerController>().SetPlayerViewRocation(-90f, 7f);
            StartCoroutine(other.GetComponent<CustomSimplePlayerController>().EnablePlayerMovementAfterDelay(2f));
            // Debug.Log("Player Entered");
        }
    }
}
