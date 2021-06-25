using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TagSelectionManagement : MonoBehaviour
{
    private OptionCollectionScript optionCollectionInstance;

    public Sprite card_srpite;
    public Image text_image;
    
    string textData;


    void Start(){
        optionCollectionInstance = GameObject.FindWithTag("OptionCollection").GetComponent<OptionCollectionScript>();
    }

    public void OnJumbotronSelected(){
        optionCollectionInstance.OnChangeTagName("div");
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();
    }

    public void OnParagraphSelected(){
        optionCollectionInstance.OnChangeTagName("p");
    }

    public void OnCardSelected(){
        optionCollectionInstance.OnChangeTagName("Card");
        GameObject current = optionCollectionInstance.GetComponent<OptionCollectionScript>()
            .GetActiveObject();
        current.GetComponent<Image>().sprite = card_srpite;
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();
    }

    public void OnHeaderSelected(string h){
        optionCollectionInstance.OnChangeTagName(h);
        optionCollectionInstance.ActiveInputField();
        GameObject current = optionCollectionInstance.GetComponent<OptionCollectionScript>().GetActiveObject();
        Image newInst = Instantiate(text_image,
                                current.transform.position,
                                current.transform.rotation,
                                current.transform);
        current.GetComponent<TagProcessing>().ChangeLayoutValues("FixedRows",1);
        gameObject.GetComponent<TweenAnimations>().OnCloseMenu();
    }

    public void OnDivSelected(){

    }
}
