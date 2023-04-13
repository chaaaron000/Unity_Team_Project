using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGetItem : MonoBehaviour
{
    private ItemDatabase itemDatabase;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
        {
            Debug.LogError("playerObject is not assigned.");
            return;
        }
        itemDatabase = playerObject.GetComponent<ItemDatabase>();
    }

    void ObjectClicked()
    {   
        if (itemDatabase == null)
        {
            Debug.LogError("ItemDatabase is not assigned.");
            return;
        }

        itemDatabase.AddData(gameObject.name);
        // Debug.Log("AddData를 실행했어요");
        Destroy(gameObject);
    }
}


/*if(this.gameObject.name == "Prism"){
            itemDatabase = GameObject.Find("Prism").GetComponent<ItemDatabase>();
        }else if(this.gameObject.name == "Cube"){
            itemDatabase = GameObject.Find("Cube").GetComponent<ItemDatabase>();
        }else if(this.gameObject.name == "Sphere"){
            itemDatabase = GameObject.Find("Sphere").GetComponent<ItemDatabase>();
        }else if((this.gameObject.name == "FlashLight")){
            itemDatabase = GameObject.Find("FlashLight").GetComponent<ItemDatabase>();
        }else{
            itemDatabase = GameObject.Find("Key").GetComponent<ItemDatabase>();
        }*/