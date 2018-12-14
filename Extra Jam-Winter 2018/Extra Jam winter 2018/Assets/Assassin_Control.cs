using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Control : MonoBehaviour {
    // Use this for initialization
    private float speed = 3f;
    void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.W))
            transform.Translate((Vector3.right + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D))
            transform.Translate((Vector3.left + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.S))
            transform.Translate((Vector3.forward + Vector3.left) * speed * 0.707f * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.A))
            transform.Translate((Vector3.forward + Vector3.right) * speed * 0.707f * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            transform.Translate(Vector3.up * 0.01f * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }
}
