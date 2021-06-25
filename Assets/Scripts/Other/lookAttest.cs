using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAttest : MonoBehaviour
{
    private Camera m_Camera;

    void Start(){
        m_Camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
