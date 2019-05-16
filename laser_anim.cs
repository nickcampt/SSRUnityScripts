using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_anim : MonoBehaviour
{
    public Sprite flash;
    public Sprite flash2;
    public GameObject laser;
    public GameObject laser_build;
    public SpriteRenderer spriteRenderer;

    private bool shooting;
    private float counter, time;
    private int build_count;
    private float stall;
    private Vector3 v;
    private float rot_speed;

    private void Start()
    {
        shooting = false;
        counter = 0;
        build_count = 0;
        time = 0;
        stall = Random.Range(1, 4);
        v = new Vector3(-1.71f, -0.03000014f, 0f);
        rot_speed = Random.Range(-30, 30);
    }

    void Update()
    {
        counter += Time.deltaTime;
        time += Time.deltaTime;

        if (time > 10)
        {
            transform.RotateAround(v, Vector3.forward, rot_speed * Time.deltaTime);
        }

        if (counter > stall && !shooting)
        {
            shooting = true;
            counter = 0;
        }

        if (shooting)
        {
            laser_build.SetActive(true);
            build_count++;

            if (build_count % 100 == 0 && counter < 2)
            {
                if (spriteRenderer.sprite == flash)
                {
                    spriteRenderer.sprite = flash2;
                }
                else
                {
                    spriteRenderer.sprite = flash;
                }
            }

            if (counter > 2 && counter < 4)
            {
                laser.SetActive(true);
            }
            else if (counter >= 4)
            {
                counter = 0;
                laser_build.SetActive(false);
                laser.SetActive(false);
                stall = Random.Range(1, 6);
                shooting = false;
            }
        }
    }
}
