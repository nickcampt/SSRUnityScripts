using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score_tracker : MonoBehaviour {

	public GameObject scoreManager;
    public GameObject targetTextOne;
    public GameObject targetTextTwo;
    public GameObject targetTextThree;
    public GameObject targetWheel; 
    public GameObject currentScoreText;
    public GameObject goodSound;
    public GameObject badSound;
    int rotationIndex = 0;
    int targetOne = 25;
    int targetTwo = 35;
    int targetThree = 40;
    bool turnRight = false;
    bool turnLeft = false;
	void Start () {
        var txt = targetTextOne.GetComponent<Text>();
        txt.text = targetOne.ToString();
        txt = targetTextTwo.GetComponent<Text>();
        txt.text = targetTwo.ToString();
        txt = targetTextThree.GetComponent<Text>();
        txt.text = targetThree.ToString();
        final_check();
	}

    float rotation_speed = 1;
    float rotation_friction = 1;
    float rotation_smoothness = 1;

    float resulting_value;
    Quaternion q_rotate_from;
    Quaternion q_rotate_to;

    float lerpMod = 0f;
    int rotation_amount = 30;
    int rotation_add = 30;
    float spinTime = 2f;
    void Update() {
        if (turnRight) {
            q_rotate_from = targetWheel.GetComponent<Transform>().rotation;
            q_rotate_to = Quaternion.Euler(0,0, -rotation_amount);
            targetWheel.GetComponent<Transform>().rotation = Quaternion.Lerp(q_rotate_from,q_rotate_to, lerpMod);
            lerpMod = lerpMod + 0.2f; 
        }
        else if (turnLeft) {
            q_rotate_from = targetWheel.GetComponent<Transform>().rotation;
            q_rotate_to = Quaternion.Euler(0,0, rotation_amount);
            targetWheel.GetComponent<Transform>().rotation = Quaternion.Lerp(q_rotate_from,q_rotate_to, lerpMod);
            lerpMod = lerpMod + 0.2f; 
        }
    }

    void final_check() {
        var m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == "final_scene") {
            scoreManager.GetComponent<score_handler>().gameEnd();
        }
    }

    bool stopping = false; 
    public void spin_wheel_positive() {
        rotationIndex = rotationIndex + 1 % 12;
        validateRotation();
        turnLeft = false;
        if (turnRight == false) {
            turnRight = true;
        }
        if (stopping == false) {
            stopping = true; 
            Invoke("stop_right", spinTime);
        }
        positiveChange(currentScoreText);
        //call color change for text
    }

    void stop_right() {
        turnRight = false;
        stopping = false;
        lerpMod = 0f;
    }

    public void spin_wheel_negative() {
        rotationIndex = rotationIndex - 1 % 12;
        validateRotation();
        turnRight = false;
        if (turnLeft == false) {
            turnLeft = true;
        }
        if (stopping == false) {
            stopping = true; 
            Invoke("stop_left", spinTime);
        }
        negativeChange(currentScoreText);
        //call color change for text
    }

    void stop_left() {
        turnLeft = false;
        stopping = false;
        lerpMod = 0f;
    }

    void negativeChange(GameObject obj) {
        obj.GetComponent<Text>().color = new Color(237/255f, 44/255f, 113/255f);
        Invoke("reset_text_color", 1f);
        badSound.GetComponent<AudioSource>().Play(0);
    }

    void positiveChange(GameObject obj) {
        obj.GetComponent<Text>().color = new Color(246/255f, 235/255f, 2/255f);
        Invoke("reset_text_color", 1f);
        goodSound.GetComponent<AudioSource>().Play(0);
    }

    void reset_text_color() {
        currentScoreText.GetComponent<Text>().color = Color.white;
    }

    void validateRotation() {
        switch (rotationIndex) {
            case 0:
                rotation_amount = 0;
                break;
            case 1:
                rotation_amount = 30;
                break;
            case 2:
                rotation_amount = 60;
                break;
            case 3:
                rotation_amount = 90;
                break;
            case 4:
                rotation_amount = 120;
                break;
            case 5:
                rotation_amount = 150;
                break;
            case 6:
                rotation_amount = 180;
                break;
            case 7:
                rotation_amount = 210;
                break;
            case 8:
                rotation_amount = 240;
                break;
            case 9:
                rotation_amount = 270;
                break;
            case 10:
                rotation_amount = 300;
                break;
            case 11:
                rotation_amount = 330;
                break;
            default:
                rotation_amount = 0;
                break;
        }
    }
	
}
