using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class logo_spin_animation : MonoBehaviour {

    int spinStage = 0;
    float lerpage = 0.01f;
    float spinTime = 0.25f;
    float currentTime = 0f;
    bool spinning = false;
    bool done = false;


    float firstTo = 135;
    float secondTo = 150;
    float thirdTo = 250;

    int timeMod = 2;

    Quaternion q_rotate_from;
    Quaternion q_rotate_to;


    public GameObject cameraObj;
	
	// Update is called once per frame
	void Update () {
        if (spinning != true) {
            if (spinStage == 1) {
                q_rotate_from = Quaternion.Euler(0, 0, 1);
                q_rotate_to = Quaternion.Euler(0,0, firstTo);
                spinning = true;
            }
            else if (spinStage == 2) {
                q_rotate_from = Quaternion.Euler(0, 0, firstTo);
                q_rotate_to = Quaternion.Euler(0,0, -secondTo);
                spinning = true;
            }
            else if (spinStage == 3) {
                q_rotate_from = Quaternion.Euler(0, 0, -secondTo);
                q_rotate_to = Quaternion.Euler(0,0, firstTo);
                spinning = true;
            }
            else if (spinStage == 4) {
                q_rotate_from = Quaternion.Euler(0, 0, firstTo);
                q_rotate_to = Quaternion.Euler(0,0, -secondTo);
                spinning = true;
            }   
     
        }
        if (cameraObj.GetComponent<camera_zoom_animation>().getAnimationCompleted() == true && done != true) {
            lerpage += 0.002f;
            currentTime += Time.deltaTime;
            //transform.rotation = Quaternion.Lerp(q_rotate_from, q_rotate_to, lerpage);
        }
        if (currentTime >= spinTime || lerpage > 1) {
            currentTime = 0f;
            lerpage = 0.1f;
            spinStage = spinStage + 1;
            spinning = false;
            if (spinStage > 4) {
                done = true;
            }
        }
        
	}

    public bool getDone() {
        return done;
    }
}
