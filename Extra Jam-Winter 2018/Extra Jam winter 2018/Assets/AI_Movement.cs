using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour {

    // Use this for initialization
    private float speed = 3f;
    private bool moving = false;
    private bool jumping = false;
    private bool falling = false;
    private int Dir;
    private float timer = 1f;
    private float clock = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (timer <= clock)
        {
            timer += Time.deltaTime;
            
        }
        else
        {
            randomDir();
            timer = 0f;
            clock = Mathf.RoundToInt(Random.Range(0.5f, 4f));

        }
        
    }

    void FixedUpdate()
    {
        
        moveDirection();
        transform.position = new Vector3(transform.position.x, (transform.position.z + 20f) / 1000f, transform.position.z);


    }



    private void moveDirection()
    {
        if (Dir == 1)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
        if (Dir == 2)
        {
            transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        }
        if (Dir == 3)
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
        if (Dir == 4)
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        if (Dir == 5)
        {
            transform.Translate((Vector3.forward + Vector3.right) * speed * 0.707f * Time.fixedDeltaTime);
        }
        if (Dir == 6)
        {
            transform.Translate((Vector3.forward + Vector3.left) * speed * 0.707f * Time.fixedDeltaTime);
        }
        if (Dir == 7)
        {
            transform.Translate((Vector3.left + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        }
        if (Dir == 8)
        {
            transform.Translate((Vector3.right + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        }
    }

    void randomDir()
    {
        Dir = Mathf.RoundToInt(Random.Range(0.5f, 8.5f));
    }
}
