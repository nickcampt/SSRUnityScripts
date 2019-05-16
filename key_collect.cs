using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_collect : MonoBehaviour
{

    public int score = 0;
    public bool collecting;

    private Vector3 v;

    private void Start()
    {
        v = new Vector3(-1.71f, -0.03000014f, 0f);
        collecting = false;
    }

    private void Update()
    {
        //if (collecting)
        //{
        //    transform.localPosition = new Vector3(0, 1f, 0);
        //}
    }
}
