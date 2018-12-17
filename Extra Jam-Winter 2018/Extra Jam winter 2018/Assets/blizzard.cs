using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blizzard : MonoBehaviour {
    public GameObject storm;
    private float timer = 0f;
    private float timer2 = 0f;
	// Use this for initialization
	void Start () {
        storm.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0f);
        
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer + Time.deltaTime;
        if (timer < 3f)
        {
            
        }
        else if (timer <5f)
        {
            timer2 = timer2 + Time.deltaTime;
            storm.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, timer2/2f);
        }
        else if (timer < 7f)
        {
            timer2 = 0f;
            storm.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (timer < 10f)
        {
            timer2 = timer2 + Time.deltaTime;
            storm.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1 - timer2 / 2f);
        }
        else
        {
            storm.SetActive(false);
        }
    }
}
