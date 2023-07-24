using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void rateAppMobile()
    {
    #if UNITY_ANDROID
        Application.OpenURL("google.com");
    #elif UNITY_IPHONE
        Application.OpenURL("google.com");
    #endif
    }
}
