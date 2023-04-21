using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSevenChasing : MonoBehaviour
{
    private Animator anim;

    public GameObject ghost;
    private GhostAnimation ghostAnim;

    public GameObject scene;
    private Animator sceneAnimator;
    
   

    // Start is called before the first frame update
    void Start()
    {   
        anim = gameObject.GetComponent<Animator>();
        sceneAnimator = GameObject.Find("Scene").GetComponent<Animator>();

        ghostAnim = ghost.GetComponent<GhostAnimation>();
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
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<CustomSimplePlayerController>().SetPlayerViewRocation(-90f, 7f);
            //StartCoroutine(other.GetComponent<CustomSimplePlayerController>().EnablePlayerMovementAfterDelay(2f));
            // Debug.Log("Player Entered");

            anim.Play("Loop7_Chasing");
            sceneAnimator.Play("Last Scene");

        }
    }

    public void PlayIdleAnim()
    {
        ghostAnim.PlayIdleAnim();
    }
    
    public void PlayWalkingAnim()
    {
        ghostAnim.PlayWalkingAnim();
    }

    public void PlayCrawlingAnim()
    {
        ghostAnim.PlayCrawlingAnim();
    }

}
