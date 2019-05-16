using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{



    public static bool move;
    private bool dirRight = true;
    public float speed = 2.0f;


    // Use this for initialization
    void Start()
    {
       
    }


    void Update()
    {

        if (move)
        {


            if (dirRight)
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            else
                transform.Translate(-Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= 0.8f)
            {
                dirRight = false;
            }

            if (transform.position.x <= -4.2)
            {
                dirRight = true;
            }
        }

    }

    public void platformOff()
    {
        move = false;
    }

    public void platformOn()
    {
        move = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
