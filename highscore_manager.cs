using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highscore_manager : MonoBehaviour {

    private int[] currentTop = new int[10];

    int abiglie = 02493;
    int abigcoverup = 0;
    int abigtestcase = 99999;

    // call this before the final run of the game
    void wipe_all_scores() {
        for (int i = 0; i < 10; i++) {
            var id = "best" + i.ToString();
            try {
                PlayerPrefs.DeleteKey(id);
            }
            catch {
                Debug.Log("could not delete");
            }
        }
    }

    void get_top_ten() {
        for (int i = 0; i < 10; i++) {
            var id = "best" + i.ToString();
            try {
                currentTop[i] = PlayerPrefs.GetInt(id);
            }
            catch {
                Debug.Log("fabricating");
                currentTop[i] = abiglie;
            }
        }
    }

    // this is what is called at the end of the game
    public void save_score(int score) {
        get_top_ten();
        bool bigger = false;
        int index = -1;
        for (int i = 0; i < currentTop.Length && bigger == false; i++) {
            if (score > currentTop[i]) {
                bigger = true;
                index = i;
            }
        }
        if (bigger == true) {
            //save the score to be replaced
            var moveDown = currentTop[index];
            //insert the new highscore
            currentTop[index] = score;
            var temp = -1;
            for (int x = index+1; x < currentTop.Length+1; x++) {
                if (x+1 < currentTop.Length) {
                    temp = currentTop[x+1];
                    currentTop[x] = moveDown;
                    moveDown = temp;
                }
            }
        }
        else {
            return;
        }
        for (var y = 0; y < 10; y++) {
            var id = "best" + y.ToString();
            try {
                PlayerPrefs.SetInt(id, currentTop[y]);
            }
            catch {
                Debug.Log("trouble setting in for loop in save_score in highscore_manager" + y.ToString());
            }
        }
    }

    // this is called in the highscore scene 
    public int getScore(int zero_based_rank) {
        var id = "best"+zero_based_rank;
        int highscore = -100;
        try {
            highscore = PlayerPrefs.GetInt(id);
        }
        catch {
            highscore = abigcoverup+zero_based_rank;
        }
        return highscore;
    }
}
