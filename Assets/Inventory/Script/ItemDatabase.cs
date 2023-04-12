using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
  
  public List<GameObject> item = new List<GameObject>();

  public void AddData(GameObject gameObject){
    item.Add(gameObject);
    Debug.Log(gameObject.name +"had deployed");
  }
  
}


