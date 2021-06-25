using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FooterElement : MonoBehaviour
{

    public Elements element = new Elements();

    private GameObject optionCollectionObject;
    private Button btn;

    public Sprite black_box;

    void Start(){
        btn = gameObject.GetComponent<Button>();
        optionCollectionObject = GameObject.FindWithTag("OptionCollection");
    
        btn.onClick.AddListener( delegate { OnClickButtonHandler(); } );
    }

    void OnClickButtonHandler(){
        optionCollectionObject.GetComponent<OptionCollectionScript>()
            .SetActiveElement(gameObject);
        optionCollectionObject.GetComponent<OptionCollectionScript>()
            .activeColurPanelField();
    }

    public class Elements{

        public string tagName;
        public string style;

        public Elements(){
            this.style = "";
            this.tagName = "footer";
        }

        public void SetStyle(string code){ this.style = code; }

    }    


    public void OnChangeColor(string code){
            Color color;
            element.SetStyle(code);
            ColorUtility.TryParseHtmlString(code,out color);
            gameObject.GetComponent<Image>().sprite = null;
            gameObject.GetComponent<Image>().color = color;
            
    }
}
