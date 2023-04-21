using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartNightScene : MonoBehaviour
{
    Animator animator;
    GameObject ladyGhost;
    public GameObject firstWord;

    public void Start()
    {
        // Canvas 아래의 FirstWord 오브젝트를 찾아 TextMeshProUGUI 컴포넌트 가져오기
        //firstWord = GameObject.Find("Canvas/FirstWord").GetComponent<GameObject>();
        firstWord.gameObject.SetActive(false);

        ladyGhost = GameObject.Find("LadyGhost");
        ladyGhost.SetActive(true);

        animator = gameObject.GetComponent<Animator>();
        animator.Play("First Scene");
        /*AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "OnAnimationEnd";
        animationEvent.time = animator.GetCurrentAnimatorStateInfo(0).length;
        animator.GetCurrentAnimatorClipInfo[0].clip.AddEvent(animationEvent);*/
    }

    public void OnAnimationEnd()
    {
        animator.enabled = false;
        //ladyGhost.SetActive(false);

    }

    public void FirstLineStart(){
        firstWord.gameObject.SetActive(true);
    }

    public void FirstLineEnd(){
        firstWord.gameObject.SetActive(false);
    }
}
