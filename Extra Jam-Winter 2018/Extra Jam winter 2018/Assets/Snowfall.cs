using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowfall : MonoBehaviour {
    float fallSpeed;
    float windSpeed;
	// Use this for initialization
	void Start () {
        randomFall();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z > 20.5f)
        {
            transform.position = new Vector3(Random.Range(-31f, 31f), transform.position.y, -transform.position.z);
            randomFall();
        }
        if(transform.position.x > 34.5f)
        {
            transform.position = new Vector3(-(transform.position.x), transform.position.y, transform.position.z);
        }else if (transform.position.x < -34.5f)
        {
            transform.position = new Vector3(-(transform.position.x), transform.position.y, transform.position.z);
        }

        transform.Translate(windSpeed * Time.deltaTime, 0f, fallSpeed * Time.deltaTime);
	}

    void randomFall()
    {
        fallSpeed = Random.Range(3f, 9f);
        windSpeed = Random.Range(-4f, 4f);

    
    }

}
