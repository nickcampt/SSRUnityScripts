using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class change_scene_button : MonoBehaviour {

	public void NextLevelButton(int index)
     {
         Application.LoadLevel(index);
     }
 
    public void NextLevelButton(string levelName)
    {
        Application.LoadLevel(levelName);
    }
}