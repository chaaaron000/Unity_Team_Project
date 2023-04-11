using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
  public static ItemDatabase instance;
  private void Awake(){
    instance = this;
  }
  public List <Item> itemDB = new List<Item>();
  [Space(20)]
  public GameObject fieldItemPrefab;
  public Vector3[] pos;


  private void Start(){
    
      GameObject go = Instantiate(fieldItemPrefab,pos[1], Quaternion.identity);
      go.GetComponent<FieldItems>().SetItem(itemDB[1]);
    
  }
  
}


