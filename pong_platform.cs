using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pong_platform : MonoBehaviour {

    public float start_rot = 0f;
    public score score;
    public make_gears gears;

    private void Start()
    {
        transform.Rotate(0, 0, start_rot);
    }

    void Update()
    {
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 0, 80 * Time.deltaTime);
        }

        else if (Input.GetKey("left"))
        {
            transform.Rotate(0, 0, -80 * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Gear")
        {
            score.score_count++;
            score.update_score();
            gears.collisions++;
            gears.changed = true;
        }
    }

}
