using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFiledScript : MonoBehaviour
{
    private GameObject optionCollectionInstance;
    public TMP_InputField inputText;

    void Start(){
        optionCollectionInstance = GameObject.FindWithTag("OptionCollection");
    }

    public void OnSubmit(){
        optionCollectionInstance.GetComponent<OptionCollectionScript>().SetHeaderText(inputText.text);
        GameObject current = optionCollectionInstance.GetComponent<OptionCollectionScript>()
            .GetActiveObject();
        GameObject imageObject = current.transform.GetChild(0).gameObject;
        imageObject.GetComponent<ImageHeader>().SetThisText(inputText.text);
        optionCollectionInstance.GetComponent<OptionCollectionScript>().OnResetSelections();
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();
    }
}
