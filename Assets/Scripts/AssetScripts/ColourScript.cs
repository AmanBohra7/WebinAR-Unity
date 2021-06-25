using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourScript : MonoBehaviour
{
 
    
    // Start is called before the first frame update
    void Start()
    {

    LeanTween.scale(gameObject.GetComponent<RectTransform>(), 
        gameObject.GetComponent<RectTransform>().localScale*10f, .5f)
            .setEaseOutBack().setDelay(1.7f);
    }

   
}
