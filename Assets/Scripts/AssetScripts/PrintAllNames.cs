using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;
using Proyecto26;

public class PrintAllNames : MonoBehaviour
{
    public GameObject mainObject;
    public GameObject navbarObject;
    public GameObject footerObject;
   
    string json;

    private readonly string API_URL = "http://localhost:5000/addData";
    private readonly string API_URL_2 = "http://192.168.0.102:5000/addData";
    

   // end part stuff
    public TextMeshProUGUI textMesh; 
    public GameObject endPart;

    public class JSONCollection{
        public List<NavbarElement.Elements> NavBar = new List<NavbarElement.Elements>();
        public List<HtmlElement.ElementData> body = new List<HtmlElement.ElementData>();
        public List<FooterElement.Elements> footer = new List<FooterElement.Elements>();

        public JSONCollection(NavbarElement.Elements n , 
                        HtmlElement.ElementData h ,
                        FooterElement.Elements f){
            this.NavBar.Add(n);
            this.body.Add(h);
            this.footer.Add(f);
        }

    }

    public void onTraverseCall(){ 
        mainObject.GetComponent<HtmlElement>().GetJsonData();
        JSONCollection collection  = new JSONCollection(
            navbarObject.GetComponent<NavbarElement>().element,
            mainObject.GetComponent<HtmlElement>().elementData,
            footerObject.GetComponent<FooterElement>().element
        );

        json = JsonConvert.SerializeObject(collection,Newtonsoft.Json.Formatting.Indented) ;
        Debug.Log(json);
        //Traverse(mainObject); 

        // end part
        endPart.SetActive(true);
        Invoke("CallLastFunctions",1.2f);
        
        
        // Sending data to server
        try{
            RestClient.Post(API_URL, json)
                .Then(response => {
                    Debug.Log(response.Data);
            });
            Debug.Log("from android");
            return;
        }
        catch{
            
        }

        // StartCoroutine(GetRequest(API_URL_2));

        //  RestClient.Post(API_URL, json)
        //         .Then(response => {
        //             Debug.Log(response.Data);
        //     });
        // Debug.Log("from localhost");
        
    }

    void CallLastFunctions(){
        textMesh.GetComponent<TypeWriterEffect>().fullText = json;
        textMesh.GetComponent<TypeWriterEffect>().StartWriting();
    }


    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
                //textPart.text = webRequest.error;
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                //textPart.text = webRequest.downloadHandler.text;
            }
        }
    }

      void Traverse(GameObject obj){
        Debug.Log(
            "Tag : "+obj.GetComponent<HtmlElement>().elementData.GetTagName()+
            " Class: "+obj.GetComponent<HtmlElement>().elementData.GetClassName()
        );
        foreach (Transform child in obj.transform){
            Traverse(child.gameObject);
        }
    }
   
}
