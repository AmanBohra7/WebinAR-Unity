using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TestAuto : MonoBehaviour
{
    [HideInInspector]
    public bool startNa = false;

    public GameObject submittedImage;

    public void LastAnimation(){
        BackAnimation();
        LeanTween.moveX(submittedImage.GetComponent<RectTransform>(), 0f, .5f)
                .setEaseOutBack()
                .setDelay(.5f);   
    }

    void Start(){
        LeanTween.moveX(gameObject.GetComponent<RectTransform>(), 0f, .5f)
                .setEaseOutBack()
                .setDelay(.2f);   
    }
    
    public void BackAnimation(){
        LeanTween.moveX(gameObject.GetComponent<RectTransform>(), -256f, .5f)
                .setEaseInBack();
    }

    void Update(){
        if(startNa){
             gameObject.GetComponent<ScrollRect>().content.localPosition = new Vector3(
                     gameObject.GetComponent<ScrollRect>().content.localPosition.x,
                      gameObject.GetComponent<ScrollRect>().content.localPosition.y + 1.8f,
                       gameObject.GetComponent<ScrollRect>().content.localPosition.z
            );
        }
    }

}
