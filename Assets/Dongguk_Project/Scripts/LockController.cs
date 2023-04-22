using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockController : MonoBehaviour
{
    public GameObject lockUI;
    public GameObject explainUI;
    public TMP_InputField passwordInput;
    public string correctPassword;
    public GameObject lockObject;
    public AudioSource audioSource;
    private bool isLocked = true;

    void Start()
    {
        // 초기화
        lockUI.SetActive(false);
        explainUI.SetActive(false);
        passwordInput.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        // Enter 키를 눌렀을 때 OnSubmitButtonClicked() 함수 호출
       
    }

    void Update()
    {
        // ESC 키를 누르면 자물쇠 UI를 닫고 게임을 재개한다.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isLocked)
            {
                OnCancelButtonClicked();
            }
        }
        
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
        Debug.Log(lockObject.name);
        isLocked = true;
        lockUI.SetActive(true);
        explainUI.SetActive(true);
        Time.timeScale = 0f;
        passwordInput.gameObject.SetActive(true);
        passwordInput.ActivateInputField();
        passwordInput.text = "";
        passwordInput.onSubmit.AddListener(delegate { OnSubmitButtonClicked(); });
    }

   void CheckPassword()
{
    string password = passwordInput.text;
    Debug.Log("CheckPassword() " + lockObject.name);
    Debug.Log("패스워드:" + password);
    if (password == correctPassword)
    {
        isLocked = false;
        lockUI.SetActive(false);
        explainUI.SetActive(false);
        passwordInput.gameObject.SetActive(false);
        Time.timeScale = 1f;
        
        // Unlock 사운드 재생
        Debug.Log("오디오 클립: " + audioSource.clip.name);
        Debug.Log("Audio Play");
        audioSource.Play();
        
        Destroy(lockObject);
        password="";
        passwordInput.text="";
    }
    else
    {
        passwordInput.text = "";
        passwordInput.ActivateInputField();
    }
}


    public void OnSubmitButtonClicked()
    {
        if (passwordInput.gameObject.activeSelf)
        {
            Debug.Log("OnSubmitButtonClicked() " + lockObject.name);
            CheckPassword();
        }
    }

    public void OnCancelButtonClicked()
    {
        lockUI.SetActive(false);
        explainUI.SetActive(false);
        passwordInput.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
