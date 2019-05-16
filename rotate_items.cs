using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_items : MonoBehaviour {

    private float rot_speed = 50;
    private Vector3 v;
	
	void Start () {

        v = new Vector3(-1.71f, -0.03000014f, 0f);

    }
	
	void Update () {
		if (Input.GetKey("right"))
        {
            transform.RotateAround(v, Vector3.forward, -rot_speed * Time.deltaTime);
        }

        if (Input.GetKey("left"))
        {
            transform.RotateAround(v, Vector3.forward, rot_speed * Time.deltaTime);
        }
	}
}
