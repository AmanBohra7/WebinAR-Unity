using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SplitOptionManager : MonoBehaviour
{
    private GameObject optionsInstance;
    private int counter = 0;
    private string splitType = "";

    public Sprite h_sprite_notselected;
    public Sprite v_sprite_notselected;
    public Sprite h_sprite_selected;
    public Sprite v_sprite_selected;
    public Button h_button;
    public Button v_button;

    public TextMeshProUGUI textMeshPro;

    void Start(){
        optionsInstance = GameObject.FindWithTag("OptionCollection");

        h_button.GetComponent<Image>().sprite = h_sprite_notselected;
        v_button.GetComponent<Image>().sprite = v_sprite_notselected;
    }

    void Update() {  textMeshPro.text = counter.ToString(); }

    public void OnIncrementCounter(){ 
        if(this.counter == 4){
            Debug.Log("Overflow !");
            return;
        }
        this.counter += 1; 
    }

    public void OnDecrementCounter(){ 
        if(this.counter == 0){
            Debug.Log("Underflow !");
            return;
        }
        this.counter -= 1; 
    }

    public void SetSplitHorizonta(){
        h_button.GetComponent<Image>().sprite = h_sprite_selected;
        v_button.GetComponent<Image>().sprite = v_sprite_notselected;
        this.splitType = "FixedRows";
    }
    public void SetSplitVertical(){
        h_button.GetComponent<Image>().sprite = h_sprite_notselected;
        v_button.GetComponent<Image>().sprite = v_sprite_selected;
        this.splitType = "FixedColumns";
    }

    public void OnSubmit(){
        Debug.Log("On submit button pressed!");
        optionsInstance.GetComponent<OptionCollectionScript>().OnSplitSubmitData(this.splitType,this.counter);
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();
    }



}
