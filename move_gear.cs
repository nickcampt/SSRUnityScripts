using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move_gear : MonoBehaviour {

    public Rigidbody2D rb;

    private float x = 0, y = 0;
    private float rotation = 0;
    private float lower_var = 0.2f, upper_var = 0.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        x = Random.Range(-1.5f, 1.5f);

        if (Mathf.Abs(x) < 0.5)
        {
            do
            {
                y = Random.Range(-1.5f, 1.5f);
            } while (Mathf.Abs(y) < 0.5);
        }
        else if (Mathf.Abs(x) > 1)
        {
            do
            {
                y = Random.Range(-1.5f, 1.5f);
            } while (Mathf.Abs(y) >= 1);
        }
        else
        {
            y = Random.Range(-1.5f, 1.5f);
        }

        rb.velocity = new Vector2(x, y);

        //rotation = Random.Range(50, 90);

        float rand = Random.Range(0.07f, 0.19f);
        transform.localScale = new Vector3(rand, rand, rand);
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Secondary")
        {
            if (x > 0)
            {
                x = -(x + Random.Range(-lower_var, upper_var));
            }
            else
            {
                x = -(x + Random.Range(-upper_var, lower_var));
            }

            if (y > 0)
            {
                y = -(y + Random.Range(-lower_var, upper_var));
            }
            else
            {
                y = -(y + Random.Range(-upper_var, lower_var));
            }

            rb.velocity = new Vector2(x, y);
        }
    }
}
