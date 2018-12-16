using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Control : MonoBehaviour {
    // Use this for initialization
    private float speed = 3f;
    private bool running = false;
    public Material up;
    public Material down;
    public Material left;
    public Material right;

    void Start () {
    
        

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            
            running = false;
        }
    }

    void FixedUpdate () {


        if (running)
        {
            speed = 5f;
        }
        else
        {
            speed = 3f;
        }

        if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.W))
            transform.Translate((Vector3.right + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D))
            transform.Translate((Vector3.left + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.S))
            transform.Translate((Vector3.forward + Vector3.left) * speed * 0.707f * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.A))
            transform.Translate((Vector3.forward + Vector3.right) * speed * 0.707f * Time.fixedDeltaTime);

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            GetComponent<MeshRenderer>().material = left;

        }
            
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<MeshRenderer>().material = right;
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
            
        else if (Input.GetKey(KeyCode.W))
        {
            GetComponent<MeshRenderer>().material = up;
            transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        }
            
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<MeshRenderer>().material = down;
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
            

        transform.position = new Vector3(transform.position.x, (transform.position.z + 20f) / 1000f, transform.position.z); 
    }


}
