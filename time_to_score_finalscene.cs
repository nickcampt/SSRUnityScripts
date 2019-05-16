using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_to_score_finalscene : MonoBehaviour {

    public GameObject thisSpeech;
    public GameObject highscoreHandler; 
    int maxScore = 10000;
	void Start () {
        var sceneTransition = GameObject.Find("Transition").GetComponent<mg_transition_anim>();
        int totalTime = Mathf.RoundToInt(sceneTransition.get_time());
        Debug.Log(totalTime);
        var editMe = thisSpeech.GetComponent<Text>();
        editMe.text = totalTime.ToString();
        int subtractor = (maxScore - ((totalTime/30) * 100));
        int score = Mathf.Max(subtractor, 0);
        highscoreHandler.GetComponent<highscore_manager>().save_score(score);
	}
	
	void Update () {
		
	}
}
