using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controls : MonoBehaviour {

    public Sprite sprite;
    public Sprite l_sprite;
    public Sprite l_sprite_step;
    public Sprite r_sprite;
    public Sprite r_sprite_step;
    public Sprite shock_sprite;
    public move_key move_key;


    public score score;


    private bool jumping, shocked;
    private int shock_count;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int counter = 0;
    private Vector3 v;

    private void Start()
    {
        jumping = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        v = new Vector3(-1.71f, -0.03000014f, 0f);
        shock_count = 0;
    }

    void Update()
    {
        if (shocked)
        {
            shock_count++;
        }
        if (shock_count > 200)
        {
            shocked = false;
            shock_count = 0;
            spriteRenderer.sprite = sprite;
        }


        if ((Input.GetKey("up") || Input.GetKey("space")) && !jumping)
        {
            rb.AddForce(new Vector2(0f, 15f));
            if (rb.velocity.y > 4.5) jumping = true;
        }

        if (Input.GetKeyUp("up") || Input.GetKeyUp("space"))
        {
            jumping = true;
        }

        if (spriteRenderer.sprite != shock_sprite)
        {
            if (Input.GetKey("right"))
            {
                if (!Input.GetKey("up"))
                    counter++;

                if (counter % 100 == 0)
                {
                    if (spriteRenderer.sprite == r_sprite)
                    {
                        spriteRenderer.sprite = r_sprite_step;
                    }
                    else
                    {
                        spriteRenderer.sprite = r_sprite;
                    }
                }
            }
            else if (Input.GetKey("left"))
            {
                if (!Input.GetKey("up"))
                    counter++;

                if (counter % 100 == 0)
                {
                    if (spriteRenderer.sprite == l_sprite)
                    {
                        spriteRenderer.sprite = l_sprite_step;
                    }
                    else
                    {
                        spriteRenderer.sprite = l_sprite;
                    }
                }
            }

            if (Input.GetKeyUp("right") || Input.GetKeyUp("left"))
            {
                spriteRenderer.sprite = sprite;
                counter = 0;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lock2")
        {
            jumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            spriteRenderer.sprite = shock_sprite;
            shocked = true;
            score.score_count--;
            score.update_score();
        }

        if (other.gameObject.tag == "Key")
        {
            score.score_count++;
            score.update_score();
            move_key.update_key();
        }
    }

    private void OnTriggerExit2D(Collider2D other)  //Doesn't work
    {
        if (other.gameObject.tag == "Laser")
        {
            spriteRenderer.sprite = sprite;
        }
    }

}
