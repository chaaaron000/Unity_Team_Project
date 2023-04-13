using UnityEngine;
using UnityEngine.UI;

public class LockController : MonoBehaviour
{
    public GameObject lockUI;
    public GameObject explainText;
    public InputField passwordInput;
    
    public string correctPassword = "108";

    private bool isLocked = true;
    private bool isShowingPasswordUI = false;

    void Start()
    {
        // 초기화
        lockUI.SetActive(false);
        explainText.SetActive(false);
        passwordInput.gameObject.SetActive(false);
    }

    void ObjectClicked()
    {
            if (isLocked)
            {
                ShowLockUI();
            }
    }

    void ShowLockUI()
    {
        isLocked = true;
        lockUI.SetActive(true);
        explainText.SetActive(true);
        Time.timeScale = 0f; // 게임 일시 정지
        passwordInput.gameObject.SetActive(true);
        passwordInput.ActivateInputField(); // 입력 필드 활성화
    }

    void CheckPassword(string password)
    {
        if (password == correctPassword)
        {
            isLocked = false;
            lockUI.SetActive(false);
            explainText.SetActive(false);
            passwordInput.gameObject.SetActive(false);
            Time.timeScale = 1f; // 게임 재개
            Destroy(gameObject);
        }
        else
        {
            passwordInput.text = "";
            passwordInput.ActivateInputField(); // 입력 필드 다시 활성화
        }
    }

    public void OnSubmitButtonClicked()
    {
        CheckPassword(passwordInput.text);
    }

    public void OnCancelButtonClicked()
    {
        lockUI.SetActive(false);
        explainText.SetActive(false);
        passwordInput.gameObject.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
        isShowingPasswordUI = false;
    }
}
