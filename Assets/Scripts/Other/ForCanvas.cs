using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForCanvas : MonoBehaviour
{
    void Start(){
        Camera mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        gameObject.GetComponent<Canvas>().worldCamera = mainCamera;
    }
}
