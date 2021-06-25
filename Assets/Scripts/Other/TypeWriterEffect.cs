using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    public TestAuto test;
    

    // Start is called before the first frame update
    public void StartWriting(){
        test.startNa = true;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText(){
        for(int i = 0 ; i < fullText.Length; i+=8){
            currentText = fullText.Substring(0,i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            // yield return new WaitForSeconds(delay);
            yield return null;
        }
        // test.over = true;
        Debug.Log("OVER");
        test.startNa  = false;
        test.LastAnimation();
    }
}
