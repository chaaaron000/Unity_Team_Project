using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGetItem : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    void ObjectClicked()
    {
        if(this.gameObject.name == "Prism"){
            itemDatabase = GameObject.Find("Prism").GetComponent<ItemDatabase>();
        }else if(this.gameObject.name == "Cube"){
            itemDatabase = GameObject.Find("Cube").GetComponent<ItemDatabase>();
        }else if(this.gameObject.name == "Sphere"){
            itemDatabase = GameObject.Find("Sphere").GetComponent<ItemDatabase>();
        }else if((this.gameObject.name == "FlashLight")){
            itemDatabase = GameObject.Find("FlashLight").GetComponent<ItemDatabase>();
        }else{
            itemDatabase = GameObject.Find("Key").GetComponent<ItemDatabase>();
        }
       
        itemDatabase.AddData(gameObject);
        Destroy(gameObject);
    }

   

}
