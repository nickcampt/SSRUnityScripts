using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mg_transition_anim : MonoBehaviour 
{
    public string scene_name;
    public static bool transition = false;
    private static int mg = 0;
    public score_handler score_handler;
    private static float time = 0;

    void Update ()
    {
        if (transition)
        {
            if (mg < 8)
            {
                Time.timeScale = 0;
                while (transform.localScale.x < 0.6f)
                {
                    transform.localScale += new Vector3(0.01f, 0.01f, 0);
                }
                if (Input.GetKey("space"))
                {
                    time += Time.timeSinceLevelLoad;
                    mg++;
                    transition = false;
                    transform.localScale = new Vector3(0, 0, 0);
                    Time.timeScale = 1;
                    SceneManager.LoadScene(scene_name);
                }
            }
            else
            {
                mg = 0;
                SceneManager.LoadScene("final_scene");
            }

        }
	}

    public int get_mg()
    {
        return mg;
    }

    public void transition_true()
    {
        transition = true;
    }

    public float get_time()
    {
        return time;
    }
}
