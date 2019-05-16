using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_music_source : MonoBehaviour {
    
    static int timesSceneOne = 0;
    static int timesSceneTwo = 0;
    static int timesSceneThree = 0;

    string firstSceneName = "gear_mg";
    string secondSceneName = "mg_360pong";
    string thirdSceneName = "mg_3";

    GameObject easyMusic;
    GameObject medMusic;
    GameObject hardMusic;

    bool allowToggle = true;
    /* thanks to holistic 3d's video on unity music */
    void Awake () {
        var thisScene = SceneManager.GetActiveScene();
        Debug.Log(thisScene.name);
        if (thisScene.name.Equals(firstSceneName)) {
            Debug.Log("== firstSceneName");
            timesSceneOne++;
            loadSceneOne();
        }
        else if (thisScene.name.Equals(secondSceneName)) {
            Debug.Log("== secondSceneName");
            timesSceneTwo++;
            loadSceneTwo();
        }
        else if (thisScene.name.Equals(thirdSceneName)) {
            Debug.Log("== thirdSceneName");
            timesSceneThree++;
            loadSceneThree();
        }

    }

    public void toggle_listener() {
        if (allowToggle == false) {
            return;
        }
        else if (AudioListener.pause == true) {
            AudioListener.pause = false;
            allowToggle = false;
            Invoke("restart_toggle", 0.5f);
            return;
        } 
        else if (AudioListener.pause == false) {
            AudioListener.pause = true;
            allowToggle = false;
            Invoke("restart_toggle", 0.5f);
            return;
        }

    }

    void restart_toggle() {
        allowToggle = true;
    }

    void loadSceneOne() {
        if (timesSceneOne == 1) {
            easyMusic = GameObject.Find("easy_music");
            easyMusic.GetComponent<AudioSource>().Play(0);
        }
        else if (timesSceneOne == 2) {
            medMusic = GameObject.Find("med_music");
            medMusic.GetComponent<AudioSource>().Play(0);
        }
        else if (timesSceneOne == 3) {
            hardMusic = GameObject.Find("hard_music");
            hardMusic.GetComponent<AudioSource>().Play(0);
        }
    }

    void loadSceneTwo() {
        if (timesSceneTwo == 1) {
            easyMusic = GameObject.Find("easy_music");
            easyMusic.GetComponent<AudioSource>().Play(0);
        }
        else if (timesSceneTwo == 2) {
            medMusic = GameObject.Find("med_music");
            medMusic.GetComponent<AudioSource>().Play(0);
        }
        else if (timesSceneTwo == 3) {
            hardMusic = GameObject.Find("hard_music");
            hardMusic.GetComponent<AudioSource>().Play(0);
        } 
    }

    void loadSceneThree() {
        if (timesSceneThree == 1) {
            easyMusic = GameObject.Find("easy_music");
            easyMusic.GetComponent<AudioSource>().Play(0);
        }
        else if (timesSceneThree == 2) {
            medMusic = GameObject.Find("med_music");
            medMusic.GetComponent<AudioSource>().Play(0);
        }
        else if (timesSceneThree == 3) {
            hardMusic = GameObject.Find("hard_music");
            hardMusic.GetComponent<AudioSource>().Play(0);
        }
    }


}
