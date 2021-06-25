using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPartAnimation : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveX(gameObject.GetComponent<RectTransform>(), 0f, .5f)
                .setEaseOutBack()
                .setDelay(.2f);   
    }
}
