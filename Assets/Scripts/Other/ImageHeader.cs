using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImageHeader : MonoBehaviour
{
   public TextMeshProUGUI textMesh;

    public void SetThisText(string str){
        textMesh.text = str;
    }

}
