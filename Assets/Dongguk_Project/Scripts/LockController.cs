using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockController : MonoBehaviour
{
    public GameObject lockUI;
    public GameObject passwordUI;
    public InputField passwordInput;
    public Text messageText;
    public string correctPassword = "123";
    private bool isLocked = true;
    

    void Start()
    {
        // 초기화
        lockUI.SetActive(false);
        passwordUI.SetActive(false);
        passwordInput.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isLocked = true;
            lockUI.SetActive(false);
            passwordUI.SetActive(false);
            passwordInput.text = "";
            passwordInput.gameObject.SetActive(false);
        }
    }

    void ObjectClicked()
    {
        if (isLocked)
        {
            ShowLockUI();
            CheckPassword(passwordInput.text);
        }
    
    }

    void ShowLockUI()
    {
        isLocked = true;
        lockUI.SetActive(true);
        passwordUI.SetActive(true);
        passwordInput.gameObject.SetActive(true);
    }

    void CheckPassword(string password)
    {
        if (password == correctPassword)
        {
            isLocked = false;
            lockUI.SetActive(false);
            passwordUI.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            passwordInput.text = "";
            passwordInput.Select();
        }
    }

    public void OnPasswordResetButtonClicked()
    {
        lockUI.SetActive(false);
        passwordUI.SetActive(true);
        passwordInput.Select();
    }

    public void OnPasswordCancelClicked()
    {
        passwordInput.text = "";
        passwordUI.SetActive(false);
        lockUI.SetActive(true);
        
    }

    
}
