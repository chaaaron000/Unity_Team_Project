using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WatchController : MonoBehaviour
{
    
    public GameObject explainUI;
    public TMP_InputField passwordInput;
    public string correctPassword;
    public GameObject lockObject;
    public TextMeshPro timeText;
    public TextMeshPro bgs; // 수정된 부분
    public GameObject key;
    public float letterChangeInterval = 100f;
    private Coroutine changeCoroutine;

    private bool isLocked = true;

    void Start()
{
    // 초기화
    key.SetActive(false);
    explainUI.SetActive(false);
    passwordInput.gameObject.SetActive(false);
    bgs.gameObject.SetActive(true);
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
        
            explainUI.SetActive(false);
            passwordInput.gameObject.SetActive(false);
            Time.timeScale = 1f;


            // 정답 입력 후 time 텍스트 업데이트
        
            timeText.text = password;
            //bgs.text = "Check The table";
            Change();
            key.SetActive(true);
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
        
        explainUI.SetActive(false);
        passwordInput.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Change()
{
    if (changeCoroutine != null) // 이전에 실행한 코루틴이 있다면 종료
    {
        StopCoroutine(changeCoroutine);
    }

    // 코루틴 실행
    changeCoroutine = StartCoroutine(ChangeTextCoroutine());
}

private IEnumerator ChangeTextCoroutine()
{
    string originalText = bgs.text; // 원래의 텍스트 저장

    // 글자를 한 글자씩 변환하는 작업
    for (int i = 0; i < originalText.Length; i++)
    {
        string newText = originalText.Substring(0, i + 1);
        bgs.text = "Check The table";
        yield return new WaitForSeconds(letterChangeInterval);
    }
}
}
