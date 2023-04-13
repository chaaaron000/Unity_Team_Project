using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public ItemOnOff itemOnOff;
    public List<GameObject> item = new List<GameObject>();

    public void AddData(GameObject gameObject)
    {
      itemOnOff = GameObject.Find("ItemOnOff").GetComponent<ItemOnOff>(); 
      Debug.Log("Adding new item: " + gameObject.name);
      item.Add(gameObject);
      Check();
      itemOnOff.SetItemOn(gameObject.name);
      // GameObject의 이름과 "Image"를 결합하여 해당 게임 오브젝트에서 ItemOnOff 컴포넌트 찾기
      //string name = gameObject.name + "Image";
      //Debug.Log(name);
      
      
    }

    public void Check()
    {
        Debug.Log("Item count: " + item.Count);
    }
}
