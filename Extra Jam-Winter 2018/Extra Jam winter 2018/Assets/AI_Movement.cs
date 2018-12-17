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
    private float animationTimer;
    private float animationClock = 2f;

   
    public Material up1;
    public Material up2;
    public Material up3;
    public Material up4;
    public Material down1;
    public Material down2;
    public Material down3;
    public Material down4;
    public Material left1;
    public Material left2;
    public Material left3;
    public Material left4;
    public Material right1;
    public Material right2;
    public Material right3;
    public Material right4;

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        animationTimer = animationTimer + Time.deltaTime;
        if (animationTimer > animationClock)
        {
            animationTimer = 0f;
        }
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

        if (transform.tag == "Target")
        {
            if (transform.position.z > 8f)
            {
                Dir = 2;
            }
            else if (transform.position.z < -8f)
            {
                Dir = 1;
            }
            if (transform.position.x > 15f)
            {
                Dir = 3;
            }
            else if (transform.position.x < -15f)
            {
                Dir = 4;
            }
        }
        if (Dir == 1)
        {
            runDown();
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
        if (Dir == 2)
        {
            runUp();
            transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        }
        if (Dir == 3)
        {
            runRight();
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
        if (Dir == 4)
        {
            runLeft();
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        if (Dir == 5)
        {
            if(Dir2 == 1)
            {
                runDown();
            }
            else if(Dir2 == 2)
            {
                runLeft();
            }

            transform.Translate((Vector3.forward + Vector3.right) * speed * 0.707f * Time.fixedDeltaTime);
        }
        if (Dir == 6)
        {
            if (Dir2 == 1)
            {
                runRight();
            }
            else if (Dir2 == 2)
            {
                runDown();
            }
            transform.Translate((Vector3.forward + Vector3.left) * speed * 0.707f * Time.fixedDeltaTime);

        }
        if (Dir == 7)
        {
            if (Dir2 == 1)
            {
                runRight();
            }
            else if (Dir2 == 2)
            {
                runUp();
            }
            transform.Translate((Vector3.left + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
        }
        if (Dir == 8)
        {
            if (Dir2 == 1)
            {
                runLeft();
            }
            else if (Dir2 == 2)
            {
                runUp();
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

    void runDown()
    {
        if (animationTimer < animationClock / 4f)
        {
            GetComponent<MeshRenderer>().material = down1;
        }
        else if (animationTimer < (animationClock / 4f)*2)
        {
            GetComponent<MeshRenderer>().material = down2;
        }
        else if (animationTimer < (animationClock / 4f) * 3)
        {
            GetComponent<MeshRenderer>().material = down3;
        }
        else if (animationTimer < (animationClock / 4f) * 4)
        {
            GetComponent<MeshRenderer>().material = down4;
        }




    }
    void runUp()
    {
        if (animationTimer < animationClock / 4f)
        {
            GetComponent<MeshRenderer>().material = up1;
        }
        else if (animationTimer < (animationClock / 4f)* 2)
        {
            GetComponent<MeshRenderer>().material = up2;
        }
        else if (animationTimer < (animationClock / 4f) * 3)
        {
            GetComponent<MeshRenderer>().material = up3;
        }
        else if (animationTimer < (animationClock / 4f) * 4)
        {
            GetComponent<MeshRenderer>().material = up4;
        }
    }
    void runLeft()
    {
        if (animationTimer < animationClock / 4f)
        {
            GetComponent<MeshRenderer>().material = left1;
        }
        else if (animationTimer < (animationClock / 4f)*2)
        {
            GetComponent<MeshRenderer>().material = left2;
        }
        else if (animationTimer < (animationClock / 4f) * 3)
        {
            GetComponent<MeshRenderer>().material = left3;
        }
        else if (animationTimer < (animationClock / 4f) * 4)
        {
            GetComponent<MeshRenderer>().material = left4;
        }
    }
    void runRight()
    {
        if (animationTimer < animationClock / 4f)
        {
            GetComponent<MeshRenderer>().material = right1;
        }
        else if (animationTimer < (animationClock / 4f) * 2)
        {
            GetComponent<MeshRenderer>().material = right2;
        }
        else if (animationTimer < (animationClock / 4f) * 3)
        {
            GetComponent<MeshRenderer>().material = right3;
        }
        else if (animationTimer < (animationClock / 4f) * 4)
        {
            GetComponent<MeshRenderer>().material = right4;
        }
    }
}
