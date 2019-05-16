using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class camera_zoom_animation : MonoBehaviour {


    float lerpage = 0f; 
    float fromVal = 0f;
    float toVal = 0f;
    float timepased = 0f;
    int maxSlides = 3;
    int slideNum = 0;

    public Camera theCamera;

    const float firstFrom = 4.15f;
    const float firstTo = 3.50f; 

    const float secondTo = 3.75f;
    const float secondFrom = 3.50f;

    const float thirdTo = 1f;
    const float thirdFrom = 3.75f;

    bool animationCompleted = false;


	// Use this for initialization
	void Start () {
		
	}
	
    //try to get a bounce animation at the start, then a lock opening animation on the logo
	void Update () {
        timepased += Time.deltaTime;
        if (timepased == 1 || lerpage > 1) {
            lerpage = 0;
            slideNum++;
        }
        if (slideNum == 1 && timepased == 1) {
            lerpage = 0;
            slideNum++;
        }  

        // zoom in
        if (slideNum == 0) {
            fromVal = firstFrom;
            toVal = firstTo;
        }
        // zoom out (a little)
        else if (slideNum == 1) {
            fromVal = secondFrom;
            toVal = secondTo;
        }
        //zoom in to logo
        else if (slideNum == 2){
            fromVal = thirdFrom;
            toVal = thirdTo;
        }
        if (slideNum < maxSlides) {
            theCamera.orthographicSize = Mathf.Lerp(fromVal, toVal, lerpage);
        }
        if (timepased > 2) {
            animationCompleted = true;
        }
        lerpage += Time.deltaTime;
	}

    public bool getAnimationCompleted() {
        return animationCompleted;
    }
}
