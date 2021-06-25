using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class HtmlElement : MonoBehaviour
{    

    [HideInInspector]
    public ElementData elementData = new ElementData();

    public string TagName;
    public string ClassName;
    public string Content;

    void Start(){
        
    }

    public void GetJsonData(){
            string json  = JsonConvert.SerializeObject(this.elementData);
            //Debug.Log(json);
    }


    public class ElementData{
        public string tagName;
        public string content;
        public string className;
        public List<ElementData> children;

        public ElementData(){
            this.className = "";
            this.content = "";
            this.tagName = "div";
            this.children = new List<ElementData>();
        }

        public ElementData(string t,string cls,string con){
            this.tagName = t;
            this.className = cls;
            this.content = con;
            this.children = new List<ElementData>();
        }

        public void OnAddChild(GameObject obj){
            children.Add(
                obj.GetComponent<ElementData>()
            );
            Debug.Log("CHILD ADDED");
        }

        public string GetTagName(){return this.tagName;}
        public string GetClassName(){return this.className;}
        public string GetContent(){return this.content;}
        public List<ElementData> GetElementDatas(){return this.children;}

        public void SetTagName(string t){
            if(t == "card") this.className += " my-div";
            else this.tagName = t;
        }
        public void SetClassName(string c){ Debug.Log(c); this.className = c;}
        public void SetContent(string c){this.content = c;}
        public void AddChildren(ElementData obj){this.children.Add(obj);}

    }


}
