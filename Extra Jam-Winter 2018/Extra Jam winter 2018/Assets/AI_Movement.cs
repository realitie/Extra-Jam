using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour {

    // Use this for initialization
    private float speed = 3f;
    private int Dir;
    private int Dir2;
    private float timer = 1f;
    private float clock = 0f;

    public Material up;
    public Material down;
    public Material left;
    public Material right;

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
        if (transform.position.z > 19.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -(transform.position.z - 0.5f));
        }
        else if (transform.position.z < -19.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -(transform.position.z + 0.5f));
        }
        if (transform.position.x > 32.75f)
        {
            transform.position = new Vector3(-(transform.position.x - 0.5f), transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -32.75f)
        {
            transform.position = new Vector3(-(transform.position.x + 0.5f), transform.position.y, transform.position.z);
        }

        if (Dir == 1)
        {
            GetComponent<MeshRenderer>().material = down;
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
        if (Dir == 2)
        {
            GetComponent<MeshRenderer>().material = up;
            transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        }
        if (Dir == 3)
        {
            GetComponent<MeshRenderer>().material = right;
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
        if (Dir == 4)
        {
            GetComponent<MeshRenderer>().material = left;
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        if (Dir == 5)
        {
            if(Dir2 == 1)
            {
                GetComponent<MeshRenderer>().material = down;
            }
            else if(Dir2 == 2)
            {
                GetComponent<MeshRenderer>().material = left;
            }

            transform.Translate((Vector3.forward + Vector3.right) * speed * 0.707f * Time.fixedDeltaTime);
        }
        if (Dir == 6)
        {
            if (Dir2 == 1)
            {
                GetComponent<MeshRenderer>().material = right;
            }
            else if (Dir2 == 2)
            {
                GetComponent<MeshRenderer>().material = down;
            }
            transform.Translate((Vector3.forward + Vector3.left) * speed * 0.707f * Time.fixedDeltaTime);

        }
        if (Dir == 7)
        {
            if (Dir2 == 1)
            {
                GetComponent<MeshRenderer>().material = right;
            }
            else if (Dir2 == 2)
            {
                GetComponent<MeshRenderer>().material = up;
            }
            transform.Translate((Vector3.left + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        }
        if (Dir == 8)
        {
            if (Dir2 == 1)
            {
                GetComponent<MeshRenderer>().material = left;
            }
            else if (Dir2 == 2)
            {
                GetComponent<MeshRenderer>().material = up;
            }
            transform.Translate((Vector3.right + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        }
    }

    void randomDir()
    {
        Dir = Mathf.RoundToInt(Random.Range(0.5f, 8.49f));
        Dir2 = Mathf.RoundToInt(Random.Range(1f, 2f));

        if(Dir > 8|Dir < 1)
        {
            Debug.Log(Dir);
        }
    }
}
