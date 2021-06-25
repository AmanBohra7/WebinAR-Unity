using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

#if UNITY_EDITOR
     using Input = GoogleARCore.InstantPreviewInput;
#endif

public class ARCoreSceneController : MonoBehaviour
{
    void Start(){
        
        QuitOnConnectionErrors();
    }

    void update(){
        if(Session.Status != SessionStatus.Tracking){
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return ;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void QuitOnConnectionErrors()
    {
        if (Session.Status ==  SessionStatus.ErrorPermissionNotGranted)
        {
        Debug.Log("Camera permission is needed to run this application.");
        }
        else if (Session.Status.IsError())
        {
            // This covers a variety of errors.  See reference for details
            // https://developers.google.com/ar/reference/unity/namespace/GoogleARCore
        Debug.Log( "ARCore encountered a problem connecting. Please restart the app." );
        }
    }
}
