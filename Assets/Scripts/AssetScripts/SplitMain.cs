using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitMain : MonoBehaviour
{

    public GameObject prefab;
    public GameObject prefab_nonFlex;

    private void CreateNewChilElemetns( GameObject pObject , int count , string className){
      
    }


    public void Split(GameObject parentGameObject,int count,string className,string type){
        Debug.Log("Split Called!");
        for(int i = 0 ; i < count; ++i){
                    GameObject newSplitObject = Instantiate(prefab,
                                parentGameObject.transform.position,
                                parentGameObject.transform.rotation,
                                parentGameObject.transform);
                    newSplitObject.GetComponent<HtmlElement>().elementData.SetClassName(className);
                    parentGameObject.GetComponent<HtmlElement>().elementData.AddChildren(newSplitObject.GetComponent<HtmlElement>().elementData);
                }
        string _temp = parentGameObject.GetComponent<HtmlElement>().elementData.GetClassName();
        
    }

}


