using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.moveY(gameObject,2.5f,.5f).setEaseOutCirc(); correct
        LeanTween.moveZ(gameObject.GetComponent<RectTransform>(), -67.5f, .5f).setEaseOutCirc();
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), gameObject.GetComponent<RectTransform>().localScale*1.5f, .5f);
    }

    // Update is called once per frame
   
   public void OnCloseMenu(){
        //LeanTween.moveY(gameObject,-0.0025f,.5f).setEaseInQuart();
        LeanTween.moveZ(gameObject.GetComponent<RectTransform>(), 65.5f, .5f).setEaseInQuart();
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), gameObject.GetComponent<RectTransform>().localScale*0f, .5f).setOnComplete(DestroyMe);
        //LeanTween.alpha(gameObject.GetComponent<RectTransform>(), .1f, .5f);
   }

   public void DestroyMe(){
       Destroy(gameObject);
   }

   public void FadeAway(){
       LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0f, 0f).setOnComplete(DestroyMe);
   }
}
