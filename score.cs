using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class score : MonoBehaviour
{
    public static int score_count = 0;
    public Text score_text;
    public Text target_text;
    public mg_transition_anim transition_anim;
    public GameObject score_tracker;

    private int[] int_mg_scores = new int[9] {5, 5, 10, 15, 20, 25, 30, 35, 40};
    private string[] str_mg_scores = new string[9] {"5", "5", "10", "15", "20", "25", "30", "35", "40"};

    public void Start()
    {
        score_count = ((transition_anim.get_mg() > 2) ? int_mg_scores[transition_anim.get_mg() - 3] : 0);
        score_text.text = score_count.ToString();
    }

    public void update_score()
    {
        if (score_count < 0)
            score_count = 0;

        if (Convert.ToInt32(score_text.text) < score_count) {
            // increase
            score_tracker.GetComponent<score_tracker>().spin_wheel_positive();
        }
        else if (Convert.ToInt32(score_text.text) > score_count) {
            //decrease
            score_tracker.GetComponent<score_tracker>().spin_wheel_negative();
        }

        score_text.text = score_count.ToString();

        if (score_text.text == str_mg_scores[transition_anim.get_mg()])
            scene_transition();
    }

    private void scene_transition()
    {
        mg_transition_anim.transition = true;
    }
}
