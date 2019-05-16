using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move_key : MonoBehaviour
{
    public float rot_speed;

    private Vector3 v;
    private bool stall = false;
    private int count = 0;
    private int count_cap;

    void Start()
    {
        do
        {
            rot_speed = Random.Range(-40f, 40f);
        } while (Mathf.Abs(rot_speed) < 0.5);

        transform.position = new Vector3(-1.71f, Random.Range(-0.03000014f, 2.65f), 0f);
        v = new Vector3(-1.71f, -0.03000014f, 0f);

        count_cap = Random.Range(20, 50);
    }

    private void Update()
    {
        if (stall)
        {
            count++;

            if (count >= count_cap)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
                stall = false;
                count = 0;
                count_cap = Random.Range(20, 50);
            }
        }
    }

    public void update_key()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        float y = Random.Range(-0.03000014f, 2.65f);
        do
        {
            rot_speed = Random.Range(-40f, 40f);
        } while (Mathf.Abs(rot_speed) < 0.5);

        transform.position = new Vector3(-1.71f, y, 0);
        transform.rotation = Quaternion.identity;
        transform.RotateAround(v, Vector3.forward, Random.Range(0, 360));

        stall = true;
    }
}
