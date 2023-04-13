using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    private Animator myAnimator;
    private Animator additionalAnimator;
    public bool objectOpen;
    public bool objectOpenAdditional;
    public GameObject animateAdditional;
    private bool hasAdditional = false;
    float myNormalizedTime;

    public enum DoorType
    {
        CantOpen,
        KeyDoor,
        QuizDoor,
        BasementDoor
    }
    public DoorType doorType;


    // Open or close animator state in start depending on selection.
    // Additional object with animator. For example another door when double doors. 
    void Start()
    {
       
        // If there is no animator in the gameobject itself, get the parent animator.
        myAnimator = GetComponent<Animator>();
        if (myAnimator == null)
        {
            myAnimator = GetComponentInParent<Animator>();
        }
        

        if (objectOpen == true)
        {
            myAnimator.Play("Open", 0, 1.0f);
        }
        if (animateAdditional != null)
            if (animateAdditional.GetComponent<DoorOpenClose>())
            {
                additionalAnimator = animateAdditional.GetComponent<Animator>();
                hasAdditional = true;
                objectOpenAdditional = animateAdditional.GetComponent<DoorOpenClose>().objectOpen;
            }
        else
            {
                hasAdditional = false;
            }
    }

    // Player clicks object. Method called from SimplePlayerUse script.

    void ObjectClicked()
    {
        if (!objectOpen)
        {
            switch (doorType)
            {
                case DoorType.CantOpen:
                    Debug.Log("열 수 없는 문입니다.");
                    return;
                case DoorType.KeyDoor:
                    Debug.Log("키로 여는 문입니다.");
                    break;
                case DoorType.QuizDoor:
                    Debug.Log("퀴즈로 여는 문입니다.");
                    break;
                case DoorType.BasementDoor:
                    Debug.Log("지하실 문입니다.");
                    break;

                default:
                    Debug.Log("올바르지 않은 타입입니다.");;
                    break;
            }
        }

        myNormalizedTime = myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (hasAdditional == false)
        {
            if (myNormalizedTime >= 1.0)
            {
                if (objectOpen == true)
                {   Debug.Log("OK~Door Open~");
                    myAnimator.Play("Close", 0, 0.0f);
                    objectOpen = false;
                }

                else
                {
                    Debug.Log("OK~Door closed~");
                    myAnimator.Play("Open", 0, 0.0f);
                    objectOpen = true;
                }
            }
        }

        if (hasAdditional == true && myNormalizedTime >= 1.0)
        {
            if (objectOpen == true)
            {
                myAnimator.Play("Close", 0, 0.0f);
                objectOpen = false;
                animateAdditional.GetComponent<DoorOpenClose>().objectOpenAdditional = false;

                if (objectOpenAdditional == true)
                {
                    additionalAnimator.Play("Close", 0, 0.0f);
                    objectOpenAdditional = false;
                    animateAdditional.GetComponent<DoorOpenClose>().objectOpen = false;
                }

            }

            else
            {
                myAnimator.Play("Open", 0, 0.0f);
                objectOpen = true;
                animateAdditional.GetComponent<DoorOpenClose>().objectOpenAdditional = true;

                if (objectOpenAdditional == false)
                {
                    additionalAnimator.Play("Open", 0, 0.0f);
                    objectOpenAdditional = true;
                    animateAdditional.GetComponent<DoorOpenClose>().objectOpen = true;

                }

            }

        }

    }

}
