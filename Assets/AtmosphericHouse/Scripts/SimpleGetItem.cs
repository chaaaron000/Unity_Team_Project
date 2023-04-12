using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGetItem : MonoBehaviour
{
    public ItemDatabase itemDatabase;

    void ObjectClicked()
    {   
        Debug.Log("this is ObjectClicked");
        Debug.Log(gameObject.name);
        itemDatabase = GameObject.Find(gameObject.name).GetComponent<ItemDatabase>();
        
        itemDatabase.AddData(this.gameObject);
        Debug.Log("AddData를 실행했어요");
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