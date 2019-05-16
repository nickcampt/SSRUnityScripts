using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class final_scores_loader : MonoBehaviour {

    GameObject linker;

	void Start () {
        linker = GameObject.Find("score_obj");
		loadScores();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void loadScores(){
        loadScoreOne();
        loadScoreTwo();
        loadScoreThree();
    }

    void loadScoreOne() {
        int t1 = linker.GetComponent<score_handler>().getTargetOne();
        GameObject.Find("score_1").GetComponent<Text>().text = t1.ToString();
    }

    void loadScoreTwo() {
        int t2 = linker.GetComponent<score_handler>().getTargetTwo();
        GameObject.Find("score_2").GetComponent<Text>().text = t2.ToString();
    }

    void loadScoreThree() {
        int t3 = linker.GetComponent<score_handler>().getTargetThree();
        GameObject.Find("score_3").GetComponent<Text>().text = t3.ToString();

    }
}
