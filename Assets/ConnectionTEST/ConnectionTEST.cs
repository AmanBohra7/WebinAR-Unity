using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Proyecto26;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class ConnectionTEST : MonoBehaviour
{

   public TextMeshProUGUI textPart;
   public TMP_InputField inputPart;
   
   private string url;

    public TestClass testClass = new TestClass();

    public class TestClass{
        public List<string> NavBar = new List<string>();
        public List<string> body = new List<string>(); 
        public List<string> footer = new List<string>();
    }

   public void onPOST(){
       url = inputPart.text;
       string jsonString = JsonConvert.SerializeObject(testClass);
       RestClient.Post(url, jsonString)
                .Then(response => {
                    Debug.Log("TEST: " +  response.Text);
                    textPart.text = response.Text;
            })
                .Catch( err => Debug.Log(err) );
   }

    public void OnGet1(){
       StartCoroutine(GetRequest(inputPart.text));
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
                textPart.text = webRequest.error;
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                textPart.text = webRequest.downloadHandler.text;
            }
        }
    }

    public void OnGet2(){
        url = inputPart.text;
        RestClient.Get(url)
            .Then(response => {
                string test = JsonUtility.ToJson(response.Data, true).ToString();
                Debug.Log("TEST: " +  response.Text);
                textPart.text = response.Text;
            })
            .Catch(error => textPart.text = error.ToString());
    }

}
