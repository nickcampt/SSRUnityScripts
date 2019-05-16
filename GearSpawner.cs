using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpawner : MonoBehaviour {

    public GameObject gear;

    public float spawnTime = 2.0f;
    public float fallSpeed = 40.0f;

    private float timer = 0;
    private int randomNumber;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if(timer> spawnTime)
        {
            spawnRandom();
            timer = 0;
        }

		
	}

    public void spawnRandom()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(226, 654), Random.Range(600, 650), Camera.main.farClipPlane / 2));
        Instantiate(gear, screenPosition, Quaternion.identity);
    }
}
