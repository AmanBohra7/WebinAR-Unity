using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class NavbarElement : MonoBehaviour
{
    private Button btn;
    private GameObject optionCollectionObject;

    private Sprite black_box;
    private Image image;

    public Elements element = new Elements();

    public class Elements{
        public string tagName;
        public string style;

        public Elements(){ this.tagName = "NavBar" ; this.style = ""; }

        public void SetStyle(string code){ this.style = code; }

    }

    void Start(){

        optionCollectionObject = GameObject.FindWithTag("OptionCollection");
        image = gameObject.GetComponent<Image>();

        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener( delegate{OnClickButtonHandler();} );
    }

    void OnClickButtonHandler(){
        optionCollectionObject.GetComponent<OptionCollectionScript>()
            .SetActiveElement(gameObject);
        optionCollectionObject.GetComponent<OptionCollectionScript>() 
            .activeColurPanelField();
    }

    public void OnChangeColor(string code){
        Color color;
        element.SetStyle(code);
        ColorUtility.TryParseHtmlString(code,out color);
        image.sprite = null;
        image.color = color;
    }

    public string OnReturnJson(){
        string json = JsonConvert.SerializeObject(element);
        return json;
    }

}
