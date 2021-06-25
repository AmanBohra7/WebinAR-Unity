 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OptionCollectionScript : MonoBehaviour
{
    private static GameObject currentElement;

    private bool anyChild = false;

    public GameObject optionsPrefab;
    public GameObject splitOptionsPrfab;
    public GameObject addTagOptionsPrefab;
    public GameObject inputFieldOptions;
    public GameObject colourPanelOtptions;

    private bool activeOptions = false;
    private bool activeSplitOptions = false;
    private bool activeAddTagoptions = false;
    private bool activeInputField = false;
    private bool activeColurPanel = false;

    public string stringForHeader = "";
    public void ChangeStringForHeader(string str) { this.stringForHeader = str; }
    public string GetStringForHeader() { return this.stringForHeader; }


    void Update(){

        if(gameObject.transform.childCount == 0){
            anyChild = false;
        }else{
            anyChild = true;
        }

        // instantiate options for the slipt menu 
        if(activeSplitOptions){
            StartCoroutine(Timeout(() => {
                    Instantiate(splitOptionsPrfab,
                            currentElement.transform.position,
                            optionsPrefab.transform.rotation,
                            gameObject.transform); }, 1.0f));
            activeSplitOptions = false;
        }

        // intantiating tag element addition menu
        if(activeAddTagoptions){
            StartCoroutine(Timeout(() => {
                    Instantiate(addTagOptionsPrefab,
                            currentElement.transform.position,
                            addTagOptionsPrefab.transform.rotation,
                            gameObject.transform); }, 1.0f));
            activeAddTagoptions = false;
        }

        if(activeInputField){
            StartCoroutine(Timeout(() => {
                    Instantiate(inputFieldOptions,
                            currentElement.transform.position,
                            addTagOptionsPrefab.transform.rotation,
                            gameObject.transform); }, 1.0f));
            activeInputField = false;
        }

        if(activeColurPanel){
            StartCoroutine(Timeout(() => {
                    Instantiate(colourPanelOtptions,
                            currentElement.transform.position,
                            addTagOptionsPrefab.transform.rotation,
                            gameObject.transform); }, 1.0f));
            activeColurPanel = false;
        }

    }

    public static IEnumerator Timeout(Action action, float time) {
        yield return new WaitForSecondsRealtime(time);
        action();
    }


    public void OnSplitSubmitData(string type,int count){
        Debug.Log(type+" : count : "+count.ToString());
        OnResetSelections();
        currentElement.GetComponent<TagProcessing>().ChangeLayoutValues(type,count);
        currentElement.GetComponent<TagProcessing>().OnInstantiateCall(type,count);
    }

    // function to main 
    public void ActivateOptions(){
        Instantiate(optionsPrefab,currentElement.transform.position,optionsPrefab.transform.rotation,gameObject.transform);
    }

    // function to activate spliting menu 
    public void AcitveSplitOption(){
        activeSplitOptions = true;
    }

    // function to activate add tag element
    public void ActiveAddTagOption(){
        activeAddTagoptions = true;
    }

    public void ActiveInputField(){
        activeInputField = true;
    }

    public void activeColurPanelField(){
        activeColurPanel = true;
    }

    public void SetHeaderText(string headerData){
        currentElement.GetComponent<HtmlElement>().elementData.SetContent(headerData);
    }

    public void OnChangeColour(string code){
        if(currentElement.gameObject.tag == "footer"){
            currentElement.GetComponent<FooterElement>().OnChangeColor(code);
        }else{
            currentElement.GetComponent<NavbarElement>().OnChangeColor(code);
        }
    }

    // function to set the current working gameobject 
    public void SetActiveElement(GameObject go){ currentElement = go; }

    public bool GetStatus(){ return this.anyChild; }

    public void OnResetSelections(){
        currentElement.GetComponent<TagProcessing>().SetbacktoBlack();
    }

    public void OnChangeTagName(string tg){
        currentElement.GetComponent<HtmlElement>().elementData.SetTagName(tg);
        OnResetSelections();
    }

    public GameObject GetActiveObject(){
        return currentElement;
    }

}
