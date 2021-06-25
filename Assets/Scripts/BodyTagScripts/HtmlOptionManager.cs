using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HtmlOptionManager : MonoBehaviour
{
    private GameObject optionCollectionObject;

    void Start(){
        optionCollectionObject = GameObject.FindWithTag("OptionCollection");
    }

    public void OnAddEvent(){
        Debug.Log("Add event called!");
        optionCollectionObject.GetComponent<OptionCollectionScript>().ActiveAddTagOption();
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();
    }
   
    public void OnSplitEvent(){
        Debug.Log("Split event Called!");
        //optionCollectionObject.GetComponent<OptionCollectionScript>();
        optionCollectionObject.GetComponent<OptionCollectionScript>().AcitveSplitOption();
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();     
    }

    public void OnCloseEvent(){
        Debug.Log("Closed!");
        optionCollectionObject.GetComponent<OptionCollectionScript>().OnResetSelections();
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();
    }
}
