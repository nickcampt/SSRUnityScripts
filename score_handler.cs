using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_handler : MonoBehaviour {


    /* 0 = easy, 1 = med, 2 = hard */
    static int difficulty = 0; 

    static int[] targets = new int[3];
    static int[] subTargets = new int[9] {5, 5, 10, 10, 15, 15, 15, 15, 20};
        
    void saveTargets(){
        saveTargetOne();
        saveTargetTwo();
        saveTargetThree();
        setGameState(1);
    }

    void saveSubTargets() {
        string id = "s1";
        for (int i = 0; i < subTargets.Length; i++) {
            PlayerPrefs.SetInt(id, subTargets[i]);
            id = id.Substring(0, id.Length - 1);
            id += i.ToString();
        }
    }

    public void gameEnd() {
        setGameState(0);
        PlayerPrefs.DeleteAll();
    }

    void setGameState(int val) {
        PlayerPrefs.SetInt("gamestate", val);
    }

    public int getGameState() {
        return PlayerPrefs.GetInt("gamestate");
    }

    void saveTargetOne() {
        PlayerPrefs.SetInt("t1", targets[0]);
    }

    public int getTargetOne() {
        return PlayerPrefs.GetInt("t1");
    }

    void saveTargetTwo() {
        PlayerPrefs.SetInt("t2", targets[1]);
    }

    public int getTargetTwo() {
        return PlayerPrefs.GetInt("t2");
    }

    void saveTargetThree() {
        PlayerPrefs.SetInt("t3", targets[2]);
    }

    public int getTargetThree() {
        return PlayerPrefs.GetInt("t3");
    }

    public int getSubTarget(int level) {
        string id = "s";
        if (difficulty == 0) {
            id = id + level.ToString();
            return PlayerPrefs.GetInt(id);
        }
        else if (difficulty == 1) {
            id = id + (level + 3).ToString();
            return PlayerPrefs.GetInt(id);
        }
        else if (difficulty == 2) {
            id = id + (level + 6).ToString();
            return PlayerPrefs.GetInt(id);
        }
        else return 99999;
    }

    public void increaseDifficulty() {
        difficulty++;
    }

    public int getDifficulty() {
        return difficulty;
    }
}
