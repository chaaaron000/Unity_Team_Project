
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSevenChasing : MonoBehaviour
{
    private Animator anim;
    public GameObject ghost;
    private GhostAnimation ghostAnim;
    public GameObject scene;
    private Animator sceneAnimator;
    public GameObject word;
    public GameObject word2;
    
   

    // Start is called before the first frame update
    void Start()
    {   
        word.gameObject.SetActive(false);
        word2.gameObject.SetActive(false);
        anim = gameObject.GetComponent<Animator>();
        sceneAnimator = GameObject.Find("Scene").GetComponent<Animator>();
        ghostAnim = ghost.GetComponent<GhostAnimation>();
        //sceneAnimator = scene.GetComponent<Animator>();

        Debug.Log("Scene object: " + sceneAnimator.gameObject.name);
        Debug.Log("Animator controller: " + sceneAnimator.runtimeAnimatorController.name);
        //Debug.Log("Current animation clip: " + sceneAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
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
           
            
            StartCoroutine(other.GetComponent<CustomSimplePlayerController>().EnablePlayerMovementAfterDelay(3f));

            if (sceneAnimator != null) {
                sceneAnimator.Play("Last Scene");
                Debug.Log("Last Scene Start");
            }
            else {
                Debug.Log("No animation clip is currently playing.");
            }

            StartCoroutine(ActivateWords()); // add this line
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


    IEnumerator ActivateWords()
    {
        
            word.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            word.gameObject.SetActive(false);

            word2.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            word2.gameObject.SetActive(false);
        
    }
}*/

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
    public GameObject word;
    public GameObject word2;
    public GameObject word3;
    
   

    // Start is called before the first frame update
    void Start()
    {   
        word.gameObject.SetActive(false);
        word2.gameObject.SetActive(false);
        word3.gameObject.SetActive(false);
        anim = gameObject.GetComponent<Animator>();
        sceneAnimator = GameObject.Find("Scene").GetComponent<Animator>();
        ghostAnim = ghost.GetComponent<GhostAnimation>();
        sceneAnimator = scene.GetComponent<Animator>();

        Debug.Log("Scene object: " + sceneAnimator.gameObject.name);
        Debug.Log("Animator controller: " + sceneAnimator.runtimeAnimatorController.name);
        //Debug.Log("Current animation clip: " + sceneAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
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
           
            
            StartCoroutine(other.GetComponent<CustomSimplePlayerController>().EnablePlayerMovementAfterDelay(3f));

            if (sceneAnimator != null) {
                sceneAnimator.enabled=true;
                sceneAnimator.Play("Last Scene");
                Debug.Log("Last Scene Start");
            }
            else {
                Debug.Log("No animation clip is currently playing.");
            }

            StartCoroutine(ActivateWords());

            /* 추가된 부분 */
            StartCoroutine(StopPlayerMovementAndTurnAround(other.gameObject));
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
        StartCoroutine(ActivateWord3());
    }


    IEnumerator ActivateWords()
    {
        
            word.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            word.gameObject.SetActive(false);

            word2.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            word2.gameObject.SetActive(false);
        
    }

    IEnumerator ActivateWord3()
    {
        
            word3.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            word3.gameObject.SetActive(false);
           
        
    }

    /* 추가된 부분 */
   IEnumerator StopPlayerMovementAndTurnAround(GameObject player)
{
    yield return new WaitForSeconds(3f); // 3초간 대기

    /* 사용자의 움직임을 멈춤 */
    player.GetComponent<CustomSimplePlayerController>().enabled = false;
    player.GetComponent<Rigidbody>().velocity = Vector3.zero;

    /* 뒤를 서서히 돌아봄 */
    Quaternion fromRotation = player.transform.rotation;
    Quaternion toRotation = Quaternion.Euler(0f, 270f, 0f);
    float duration = 3f; // 2초 동안 회전
    float t = 0f;
    while (t < duration)
    {
        player.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, t / duration);
        t += Time.deltaTime;
        yield return null;
    }

    yield return new WaitForSeconds(6f); // 3초간 대기

    player.GetComponent<CustomSimplePlayerController>().enabled = true; // 움직임 활성화
}

}


