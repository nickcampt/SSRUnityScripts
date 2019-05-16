using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_background : MonoBehaviour
{

    public Camera cam;

    bool change = false;
    float timer = 0;


    public void Update()
    {
        if (change && timer < 0.5)
        {
            cam.backgroundColor = new Vector4(0.9882354f, 0.1568628f, 0.4392157f);
            timer += Time.deltaTime;
        }

        if (timer >= 0.5)
        {
            cam.backgroundColor = new Vector4(0.0509804f, 0.05882353f, 0.04313726f);
            timer = 0;
            change = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //cam.backgroundColor = new Vector4(0.3f, 0.4f, 0.6f);

        if (other.gameObject.tag == "Gear")
        {
            change = true;
        }
    }
}

