using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class protag_anim : MonoBehaviour {

    public Sprite forward;
    public Sprite right1;
    public Sprite right2;
    public Sprite left1;
    public Sprite left2;
    private SpriteRenderer spriteRenderer;

    private bool walking_left;
    private bool walking_right;
    private float counter;
    private int step_count;
    private Vector3 v;
	
	void Start () 
    {
        walking_left = false;
        walking_right = true;
        counter = 0;
        step_count = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        v = new Vector3(-1.71f, -0.03000014f, 0f);
    }
	
	void Update () 
    {
        counter += Time.deltaTime;

        if ((int)Mathf.Round(counter) == 1) walking_right = true;

		if (walking_right)
        {
            step_count++;
            if (step_count % 100 == 0)
            {
                if (spriteRenderer.sprite == right1)
                {
                    spriteRenderer.sprite = right2;
                }
                else
                {
                    spriteRenderer.sprite = right1;
                }
            }

            transform.RotateAround(v, Vector3.forward, -6 * Time.deltaTime);

            if (counter >= 3)
            {
                walking_right = false;
                spriteRenderer.sprite = forward;
            }
        }

        if ((int)Mathf.Round(counter) == 4) walking_left = true;

        if (walking_left)
        {
            step_count++;
            if (step_count % 100 == 0)
            {
                if (spriteRenderer.sprite == left1)
                {
                    spriteRenderer.sprite = left2;
                }
                else
                {
                    spriteRenderer.sprite = left1;
                }
            }

            transform.RotateAround(v, Vector3.forward, 6 * Time.deltaTime);

            if (counter >= 6)
            {
                walking_left = false;
                spriteRenderer.sprite = forward;
                counter = 0;
            }
        }
    }
}
