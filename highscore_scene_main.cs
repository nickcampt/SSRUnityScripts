using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore_scene_main : MonoBehaviour {

    public GameObject number_one_score;
    public GameObject rotating_score;
    public GameObject score_master;
    public GameObject current_label;

    Quaternion q_rotate_from;
    Quaternion q_rotate_to;

    float countToTwo = 0f;
    int whichScoreAreWeOn = 0;
    bool rotate = true;
    float lerpMod = 0f;

	// Use this for initialization
	void Start () {
		// load up the number one score in both the #1 spot and the rotation spot
        var highscore = score_master.GetComponent<highscore_manager>().getScore(whichScoreAreWeOn);

        number_one_score.GetComponent<Text>().text = highscore.ToString(); 
        rotating_score.GetComponent<Text>().text = highscore.ToString();

        q_rotate_to = transform.rotation;
        q_rotate_from = new Quaternion(0, 0, 360, 1);
	}
	
	// Update is called once per frame
	void Update () {
		countToTwo = countToTwo + Time.deltaTime;
        if (countToTwo >= 2) {
            whichScoreAreWeOn++;
            whichScoreAreWeOn = whichScoreAreWeOn % 10;
            countToTwo = 0;
            var highscore = score_master.GetComponent<highscore_manager>().getScore(whichScoreAreWeOn);
            rotating_score.GetComponent<Text>().text = highscore.ToString();
            current_label.GetComponent<Text>().text = (whichScoreAreWeOn+1).ToString();
            Debug.Log("updating rotating");
        }
	}
}
