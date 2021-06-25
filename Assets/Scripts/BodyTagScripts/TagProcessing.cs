using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TagProcessing : MonoBehaviour
{
    private Button btn;
    private GameObject instantiateHere;

    public Sprite white_box;
    public Sprite black_box;

    public GameObject prefab;

    void Start(){
        instantiateHere = GameObject.FindWithTag("OptionCollection");
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener( delegate{OnClickButtonHandler();} );
    }

    // called when an body compenent is tapped 
    void OnClickButtonHandler(){
        Debug.Log("tag processing called!");
        if(!instantiateHere.GetComponent<OptionCollectionScript>().GetStatus()){
            gameObject.GetComponent<Image>().sprite = white_box;
            instantiateHere.GetComponent<OptionCollectionScript>().SetActiveElement(gameObject);
            instantiateHere.GetComponent<OptionCollectionScript>().ActivateOptions();
        }
    }

    public void SetbacktoBlack(){
        gameObject.GetComponent<Image>().sprite = black_box;
    }

    public void ChangeLayoutValues(string type,int count){
        
        // changing the grid layout values for unity display
        FlexibleGridLayout FXInstance = gameObject.GetComponent<FlexibleGridLayout>();
        if(type == "FixedColumns"){
            FXInstance.fitType = FlexibleGridLayout.FitType.FixedColumns;
            FXInstance.rows  = count;
            FXInstance.columns = 1;
            FXInstance.spacing.y = 1;
           // gameObject.GetComponent<HtmlElement>().elementData.SetClassName("flex");
        }    
        else if(type == "FixedRows"){
            FXInstance.fitType = FlexibleGridLayout.FitType.FixedRows;
            FXInstance.rows  = 1;
            FXInstance.columns = count;
            FXInstance.spacing.x = 1;
           // gameObject.GetComponent<HtmlElement>().elementData.SetClassName("non_flex");
        }
        else{
            Debug.Log("ERROR TYPE NOT SPECIFIED !");
            return;
        }
        
    }

    public void OnInstantiateCall(string type,int count){
        string className = "";
        if(type == "FixedColumns"){
            className = "row p-5 justify-content-around";
        }else{
            className = "col-"+(6-count).ToString()+" my-div";
        }
        Debug.Log("Called with class: "+className);
        GameObject splitter = GameObject.FindWithTag("SplitMain");
        splitter.GetComponent<SplitMain>().Split(gameObject,count,className,type);
    }

}
