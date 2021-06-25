using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class Scoreboard : MonoBehaviour
{
   public GameObject obj1;
   public GameObject obj2;
   private bool testBool = false;

    void Update(){
        testBool = TestSceneController.intialized;
        if(testBool){
            obj1.SetActive(false);
            obj2.SetActive(false);
        }
    }

}
