using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public ItemOnOff itemOnOff;
    public List<string> item = new List<string>();

    public void Start(){
      itemOnOff = GameObject.Find("ItemOnOff").GetComponent<ItemOnOff>();
    }

    public void AddData(string objectName)
    {
      item.Add(objectName);
      Debug.Log(item[item.Count-1]+ "여기서 확인"); 
      itemOnOff.SetItemOn(objectName);
      //Check();
      // GameObject의 이름과 "Image"를 결합하여 해당 게임 오브젝트에서 ItemOnOff 컴포넌트 찾기
      // string name = gameObject.name + "Image";
      // Debug.Log(name);    
    }

    public void DeleteData(string objectName){
      itemOnOff.SetItemOff(objectName);
    }

    public void Check()
    {
      // Debug.Log("Item count: " + item.Count);
    }
}
