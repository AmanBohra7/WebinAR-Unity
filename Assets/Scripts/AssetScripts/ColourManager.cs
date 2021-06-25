using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    private GameObject optionCollectionObject;

    void Start(){
        optionCollectionObject = GameObject.FindWithTag("OptionCollection");
    }

    public void OnColorSelected(string code){
        optionCollectionObject.GetComponent<OptionCollectionScript>()
            .OnChangeColour(code);
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();
    }

}
