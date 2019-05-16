using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroy_gear : MonoBehaviour 
{
    public make_gears gear;
    public score score;

    private static int num_destroyed = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Gear")
        {
            Destroy(other.gameObject);

            if (score.score_count > 1)
                score.score_count--;
            else
                score.score_count = 0;
            score.update_score();

            gear.decrease_gear_count();

            if (gear.get_gear_count() < 4 && (gear.get_gear_count() < 1 || num_destroyed % 2 == 0))
                gear.generate_gear();

            num_destroyed++;

        }
    }
}
