using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_selection : MonoBehaviour {

    bool movePause = false;
    int oIndex = 0; /* oIndex = options index */
    const int mIndex = 3; /* mIndex = max Index */
    public int sceneNum;
    public GameObject selectSound;
    public GameObject backSound;
    public GameObject miscSound1;
    public GameObject miscSound2;
    bool allowLeftTurn = false;
    bool allowRightTurn = false;
    Quaternion q_rotate_from;
    Quaternion q_rotate_to;
    float lerpMod = 0f;
    int rotationAmount = 0;

    public GameObject musicManager;

    /* highscore options */
    string[] highscores = new string[10];

	// Update is called once per frame
    void Update () {
        if (movePause != true)
        {
            // turn left 
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playRotate();
                turnLeft();
            }
            // turn right
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                playRotate();
                turnRight();
            }
        }
        if (Input.GetKey(KeyCode.Return) ||
            Input.GetKey(KeyCode.Space))
        {
            playSelect();
            Invoke("selectOption", 0.5f);
        }

        if (Input.GetKey(KeyCode.Backspace) ||
            Input.GetKey(KeyCode.Delete)) {
            playGoBack();
            Invoke("loadMain", 0.5f);
        }

        if (allowLeftTurn) {
            transform.rotation = Quaternion.Lerp(q_rotate_from, q_rotate_to, lerpMod);
            lerpMod += 0.2f;
        }

        else if (allowRightTurn) {
            transform.rotation = Quaternion.Lerp(q_rotate_from, q_rotate_to, lerpMod);
            lerpMod += 0.2f;
        }
    }

    void handleMovePause() {
        movePause = true;
        Invoke("unpause", 0.5f);
    }

    void unpause() {
        allowRightTurn = false;
        allowLeftTurn = false;
        movePause = false;
        lerpMod = 0;
    }

    int reduceIndex(int index, int maxIndex) {
        if (index == 0) {
            index = maxIndex;
        }
        else {
            index--;
        }
        return index; 
    }

    int increaseIndex(int index, int maxIndex) {
        if (index == maxIndex) {
            index = 0;
        }
        else {
            index++;
        }
        return index;
    }

    void validateRotation() {
        if (oIndex == 0) {
            rotationAmount = 0;
        }
        else if (oIndex == 1) {
            rotationAmount = 90;
        }
        else if (oIndex == 2) {
            rotationAmount = 180;
        }
        else if (oIndex == 3) {
            rotationAmount = 270;
        }
    }

    void turnLeft() {
        oIndex = reduceIndex(oIndex, mIndex);
        validateRotation();
        q_rotate_from = transform.rotation;
        q_rotate_to = Quaternion.Euler(0,0, rotationAmount);
        allowLeftTurn = true;
        handleMovePause();
    }

    void turnRight() {
        oIndex = increaseIndex(oIndex, mIndex);
        validateRotation();
        q_rotate_from = transform.rotation;
        q_rotate_to = Quaternion.Euler(0, 0, rotationAmount);
        allowRightTurn = true;
        handleMovePause();
    }

    void selectOption() {

        /* sceneNum 0 is the start menu */
       
        if (sceneNum == 0) {   
            /* 0 = start */
            if (oIndex == 0) {
                loadStart();
            }
            /* 1 = options */
            else if (oIndex == 1) {
                loadOptions();
            }
            /* 2 = score */
            else if (oIndex == 2) {
                loadScore();
            }
            /* 3 = quit */
            else if (oIndex == 3) {
                loadQuit();
            }
        }

        /* sceneNum 1 is the options menu */
        else if (sceneNum == 1){
            /* 0 = sound */
            if (oIndex == 0) {
                loadSound();
            }
            /* 1 = controls */
            else if (oIndex == 1) {
                loadControls();
            }
            /* 2 = speed */
            else if (oIndex == 2) {
                loadSpeed();
            }
            /* 3 = resolution */
            else if (oIndex == 3) {
                loadResolution();
            }
        }

        /* sceneNum 2 is the highscores */
        else if (sceneNum == 2) {
            loadMain();
        }

    }

    void loadStart() {
        SceneManager.LoadScene("gear_mg");
    }

    void loadOptions() {
        SceneManager.LoadScene("options");
    }

    void loadScore() {
        SceneManager.LoadScene("high_scores");
    }

    void loadQuit(){
        Application.Quit();
    }

    void loadSound() {
        musicManager = GameObject.Find("game_music");
        musicManager.GetComponent<game_music_source>().toggle_listener();
    }

    void loadControls() {

    }

    void loadSpeed() {

    }

    void loadResolution() {

    }

    void loadMain() {
        SceneManager.LoadScene("opening_scene2");
    }

    void playSelect() {
        selectSound.GetComponent<AudioSource>().Play(0);
    }

    void playGoBack(){
        backSound.GetComponent<AudioSource>().Play(0);
    }

    void playRotate(){
        miscSound2.GetComponent<AudioSource>().Play(0);
    }

}
