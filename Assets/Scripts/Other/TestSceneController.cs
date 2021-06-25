using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
     using Input = GoogleARCore.InstantPreviewInput;
#endif

public class TestSceneController : MonoBehaviour
{
        public static bool intialized  = false;

        Anchor anchor = null;

        public GameObject whiteBoardPrefab;
        private GameObject whiteBoardObject;

        private int screenHeight;
        private int screenWidth;

        public Camera FirstPersonCamera;
        public GameObject bootstrapPrefab;

        private bool m_IsQuitting = false;
        private bool dummyInitalized = false;

        private bool appInitalized = false;

        private GameObject bootstrapObject;
        
        public void Awake(){      
            Application.targetFrameRate = 60;
        }

        void Start(){
            screenHeight = Screen.height;
            screenWidth = Screen.width;
        }

        public void Update()
        {
            _UpdateApplicationLifecycle();

            Vector2 centerPose = new Vector2(screenWidth * 0.5f, screenHeight * 0.5f);
            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                TrackableHitFlags.FeaturePointWithSurfaceNormal;

            if (Frame.Raycast(centerPose.x, centerPose.y, raycastFilter, out hit))
            {
                    if(hit.Trackable is DetectedPlane){
                        if(!dummyInitalized && !appInitalized){
                            bootstrapObject = Instantiate(bootstrapPrefab,hit.Pose.position,bootstrapPrefab.transform.rotation);
                            dummyInitalized = true;
                        }else if(!appInitalized) {
                            bootstrapObject.transform.position = hit.Pose.position;
                        }

                        if(Input.touchCount > 0 && dummyInitalized && !appInitalized){
                            appInitalized = true;
                            intialized = true;
                            whiteBoardObject = Instantiate(
                                whiteBoardPrefab,
                                hit.Pose.position,
                                whiteBoardPrefab.transform.rotation
                            );
                            Destroy(bootstrapObject);
                            anchor = hit.Trackable.CreateAnchor(hit.Pose);
                            whiteBoardObject.transform.parent = anchor.transform;
                        }
                    }
                
            }
        }

        private void _UpdateApplicationLifecycle()
        {

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Session.Status != SessionStatus.Tracking)
            {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            if (m_IsQuitting)
            {
                return;
            }
         
            if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (Session.Status.IsError())
            {
                _ShowAndroidToastMessage(
                    "ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }

        private void _DoQuit()
        {
            Application.Quit();
        }

        private void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity =
                unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject =
                        toastClass.CallStatic<AndroidJavaObject>(
                            "makeText", unityActivity, message, 0);
                    toastObject.Call("show");
                }));
            }
        }
    }
