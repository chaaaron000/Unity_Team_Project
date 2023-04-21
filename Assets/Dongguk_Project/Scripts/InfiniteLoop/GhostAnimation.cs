using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostAnimation : MonoBehaviour
{
    private Animator anim;

    private bool touched = false;

    private float timer = 0.0f;
    private float waitTime = 2.0f;
    private bool startTimer = false;

    private string nextScene = "EndScene";

    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
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
            startTimer = true;

            other.GetComponent<CustomSimplePlayerController>().SetPlayerViewRocation(-90f, 7f);
            other.GetComponent<CustomSimplePlayerController>().SwitchCanMove(false);
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

    public void WalkingAnimation(){
        anim.Play("Walking");
        gameObject.SetActive(true);
    }

    public void StayAnimation(){
        anim.Play("Idle_1");
    }
    public void ChasingAnimation(){
        anim.Play("Crawling");
    }
}
