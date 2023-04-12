using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemOnOff : MonoBehaviour
{
    private Canvas canvas;
    public Image cube;

    private void Awake()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
    }
    
    public void SetItemOn(string gameObjectName)
    {
        if (canvas != null)
        {
            Debug.Log("this is SetItemOn");
            Transform inventoryUI = canvas.transform.Find("InventoryUI");
            Transform cubeTransform = inventoryUI.Find(gameObjectName);
            if (cubeTransform != null)
            {
                cube = cubeTransform.GetComponent<Image>();
                if (cube != null)
                {
                    cube.enabled = true;
                }
                else
                {
                    Debug.LogWarning("Cube component is missing!");
                }
            }
            else
            {
                Debug.LogWarning(gameObjectName + " not found in InventoryUI!");
            }
        }
        else
        {
            Debug.LogWarning("Canvas is missing!");
        }
    }   
}

      /*GameObject InventoryUI = GameObject.Find("Canvas/InventoryUI");
      Debug.Log("CanvasClear");
      Debug.Log(gameObjectName);
      Cube = InventoryUI.transform.Find(gameObjectName).
      GetComponent<Image>();
      Debug.Log("CubeImageClear");
      image = Cube.GetComponent<Image>();
      Debug.Log("ImageCLear");
      image.enabled = true;*/


/*
 public void SetItemOff(string gameObjectName)
    {
        Debug.Log("this is SetItemOff");
        GameObject gameObject = GameObject.Find(gameObjectName+"Image");
        image = gameObject.GetComponent<Image>();
        image.enabled = false;
    }*/