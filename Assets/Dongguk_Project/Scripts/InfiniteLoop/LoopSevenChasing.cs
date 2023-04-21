using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSevenChasing : MonoBehaviour
{
    private Animator anim;

    public GameObject ghost;
    private GhostAnimation ghostAnim;
    public GameObject scene;
    //GameObject sceneAnimator;
    //public GameObject ghost;
   

    // Start is called before the first frame update
    void Start()
    {   
        anim = gameObject.GetComponent<Animator>();
        ghostAnim = ghost.GetComponent<GhostAnimation>();
        ghost.SetActive(false);
        //sceneAnimator = scene.GetComponent<Animator>();
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
        ghost.SetActive(true);
        if (other.CompareTag("Player"))
        {
            anim.Play("Loop7_WalkingDown");
            
            ghostAnim.WalkingAnimation();
            //other.GetComponent<CustomSimplePlayerController>().SetPlayerViewRocation(-90f, 7f);
            //StartCoroutine(other.GetComponent<CustomSimplePlayerController>().EnablePlayerMovementAfterDelay(2f));
            // Debug.Log("Player Entered");

            anim=scene.GetComponent<Animator>();
            anim.Play("Last Scene");


            anim = gameObject.GetComponent<Animator>();
            Debug.Log("LastScene on");
        }
    }
    
    void OnStayAnimation(){
        
        anim.StopPlayback();
        anim.Play("Loop7_Stay");

        ghostAnim.StayAnimation();
        Debug.Log("Stay on");
    }

    void OnChasingAnimation(){
        anim.StopPlayback();
        anim.Play("Loop7_Chasing");
        ghostAnim.ChasingAnimation();
        Debug.Log("chasing on");
    }



}
