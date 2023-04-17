using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public CanvasGroup inventoryCanvasGroup;
    public float fadeTime = 0.5f;

    private bool isShowing = false;
    private float currentFadeTime = 0f;

    private void Start()
    {
        // 시작할 때는 InventoryUI를 숨긴다.
        inventoryCanvasGroup.alpha = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isShowing = !isShowing;
            currentFadeTime = 0f;
        }

        if (isShowing && currentFadeTime < fadeTime)
        {
            float t = currentFadeTime / fadeTime;
            inventoryCanvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
            currentFadeTime += Time.deltaTime;
        }
        else if (!isShowing && currentFadeTime < fadeTime)
        {
            float t = currentFadeTime / fadeTime;
            inventoryCanvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            currentFadeTime += Time.deltaTime;
        }
        else if (!isShowing)
        {
            inventoryCanvasGroup.alpha = 0f;
        }
    }
}



//탭누르면 등장장
        /*if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("Inventory on");
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject inventoryPanel;
    bool activeInventory = false;
    
    private void Start(){
        inventoryPanel.SetActive(activeInventory);
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }
}*/


