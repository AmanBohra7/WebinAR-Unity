using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SecondConnection : MonoBehaviour
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
       
   }

    public void OnGet(){
        Debug.Log("GET CALLED@");
       GetRequest(inputPart.text);
    }

    IEnumerator GetRequest(string url){
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:5000/test");
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

}
