using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Control : MonoBehaviour {
    // Use this for initialization
    private float speed = 3f;
    private bool running = false;
    private bool knife = false;
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
    private float cCooldown = 0f;
    public GameObject assassinWin;
    public GameObject reticle;
    public Material kup1;
    public Material kup2;
    public Material kup3;
    public Material kup4;
    public Material kdown1;
    public Material kdown2;
    public Material kdown3;
    public Material kdown4;
    public Material kleft1;
    public Material kleft2;
    public Material kleft3;
    public Material kleft4;
    public Material kright1;
    public Material kright2;
    public Material kright3;
    public Material kright4;
    private float indicatorCD= 0f;
    public MeshRenderer Photo;
    private int last = 4;
    private float animationTimer= 0f;
    private float animationClock= 2f;
    private float knifeTimer = 0f;
    private float knifeClock = 1f;
    RaycastHit hit;
    RaycastHit hit2;
    private int targetCount= 0;
    void Start () {
        hit = new RaycastHit();
        transform.position = new Vector3(Random.Range(-30f, 30f), 1, Random.Range(-16f, 16f));
        transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if(indicatorCD< 4f)
        {
            indicatorCD = indicatorCD + Time.deltaTime;

        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        } 


        cCooldown = cCooldown + Time.deltaTime;
        if (targetCount >= 4)
        {
            assassinWin.SetActive(true);
            reticle.GetComponent<Reticle>().gameOver = true;

        }
        Photo.material = down1;
        if (Input.GetKey(KeyCode.Space) & cCooldown>3f)
        {
            knife = true;
        }
        if (knife)
        {
            
            knifeTimer = knifeTimer + Time.deltaTime;
        }
        if(knifeTimer> knifeClock)
        {
            knife = false;
            knifeTimer = 0f;
        }
        
        animationTimer = animationTimer + Time.deltaTime;
        if (animationTimer > animationClock)
        {
            animationTimer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            
            running = false;
        }
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
    }

    void FixedUpdate () {


        if (running)
        {
            speed = 5.1f;
        }
        else
        {
            speed = 3f;
        }

        if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.W))
        {
            transform.Translate((Vector3.right + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
            if (last == 1) runLeft();
            else if (last == 3) runUp();
        }

        else if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D)) { 
            transform.Translate((Vector3.left + Vector3.back) * speed * 0.707f * Time.fixedDeltaTime);
            if (last == 2) runRight();
            else if (last == 3) runUp();
        }

        else if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.S)) { 
            transform.Translate((Vector3.forward + Vector3.left) * speed * 0.707f * Time.fixedDeltaTime);
            if (last == 2) runRight();
            else if (last == 4) runDown();
        }
        else if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.A)) { 
            transform.Translate((Vector3.forward + Vector3.right) * speed * 0.707f * Time.fixedDeltaTime);
            if (last == 1) runLeft();
            else if (last == 4) runDown();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            runLeft();
            last = 1;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            runRight();
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            last = 2;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            runUp();
            transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
            last = 3;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            runDown();
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
            last = 4;
        }
        else if(knife)
        { if (last == 3)
            {
                if (knifeTimer < (knifeClock / 8f))
                {
                    
                    
                    GetComponent<MeshRenderer>().material = kup1;
                }
                else if (knifeTimer < (knifeClock / 4f) * 2)
                {
                    if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Vector3.back, out hit) & hit.distance < 1.5f)
                    {
                        hit.collider.GetComponent<AI_Movement>().enabled = false;
                        cCooldown = 0f;

                        if (hit.collider.gameObject.tag == "Target" & !hit.collider.gameObject.transform.GetChild(1).gameObject.activeSelf)
                        {
                            /*game over*/

                            targetCount++;

                        }
                        if (hit.collider.gameObject.tag == "Crowd")
                        {
                            /*omaigod you shot a civilian, assassin wins*/
                            up1 = hit.collider.GetComponent<AI_Movement>().up1;
                            up2 = hit.collider.GetComponent<AI_Movement>().up2;
                            up3 = hit.collider.GetComponent<AI_Movement>().up3;
                            up4 = hit.collider.GetComponent<AI_Movement>().up4;

                            down1 = hit.collider.GetComponent<AI_Movement>().down1;
                            down2 = hit.collider.GetComponent<AI_Movement>().down2;
                            down3 = hit.collider.GetComponent<AI_Movement>().down3;
                            down4 = hit.collider.GetComponent<AI_Movement>().down4;

                            right1 = hit.collider.GetComponent<AI_Movement>().right1;
                            right2 = hit.collider.GetComponent<AI_Movement>().right2;
                            right3 = hit.collider.GetComponent<AI_Movement>().right3;
                            right4 = hit.collider.GetComponent<AI_Movement>().right4;

                            left1 = hit.collider.GetComponent<AI_Movement>().left1;
                            left2 = hit.collider.GetComponent<AI_Movement>().left2;
                            left3 = hit.collider.GetComponent<AI_Movement>().left3;
                            left4 = hit.collider.GetComponent<AI_Movement>().left4;
                        }
                        
                    }
                    
                    GetComponent<MeshRenderer>().material = kup2;
                }
                else if (knifeTimer < (knifeClock / 4f) * 3)
                {
                    GetComponent<MeshRenderer>().material = kup3;
                }
                else if (knifeTimer < (knifeClock / 4f) * 4)
                {
                    GetComponent<MeshRenderer>().material = kup4;
                }
            }else if (last == 4)
            {
                if (knifeTimer < (knifeClock / 8f))
                {
                    
                    GetComponent<MeshRenderer>().material = kdown1;
                }
                else if (knifeTimer < (knifeClock / 4f) * 2)
                {
                    if ((Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Vector3.forward, out hit) & hit.distance < 1.5f))
                    {
                        hit.collider.GetComponent<AI_Movement>().enabled = false;
                        cCooldown = 0f;
                        if (hit.collider.gameObject.tag == "Target" & !hit.collider.gameObject.transform.GetChild(1).gameObject.activeSelf)
                        {
                            /*game over*/

                            targetCount++;

                        }
                        if (hit.collider.gameObject.tag == "Crowd")
                        {
                            /*omaigod you shot a civilian, assassin wins*/
                            up1 = hit.collider.GetComponent<AI_Movement>().up1;
                            up2 = hit.collider.GetComponent<AI_Movement>().up2;
                            up3 = hit.collider.GetComponent<AI_Movement>().up3;
                            up4 = hit.collider.GetComponent<AI_Movement>().up4;

                            down1 = hit.collider.GetComponent<AI_Movement>().down1;
                            down2 = hit.collider.GetComponent<AI_Movement>().down2;
                            down3 = hit.collider.GetComponent<AI_Movement>().down3;
                            down4 = hit.collider.GetComponent<AI_Movement>().down4;

                            right1 = hit.collider.GetComponent<AI_Movement>().right1;
                            right2 = hit.collider.GetComponent<AI_Movement>().right2;
                            right3 = hit.collider.GetComponent<AI_Movement>().right3;
                            right4 = hit.collider.GetComponent<AI_Movement>().right4;

                            left1 = hit.collider.GetComponent<AI_Movement>().left1;
                            left2 = hit.collider.GetComponent<AI_Movement>().left2;
                            left3 = hit.collider.GetComponent<AI_Movement>().left3;
                            left4 = hit.collider.GetComponent<AI_Movement>().left4;
                        }
hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    
                    GetComponent<MeshRenderer>().material = kdown2;
                }
                else if (knifeTimer < (knifeClock / 4f) * 3)
                {
                    GetComponent<MeshRenderer>().material = kdown3;
                }
                else if (knifeTimer < (knifeClock / 4f) * 4)
                {
                    GetComponent<MeshRenderer>().material = kdown4;
                }
            }
            else if (last == 2)
            {
                if (knifeTimer < (knifeClock / 8f))
                {
                   
                    
                    GetComponent<MeshRenderer>().material = kright1;
                }
                else if (knifeTimer < (knifeClock / 4f) * 2)
                {
                    if ((Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Vector3.left, out hit) & hit.distance < 1.5f))
                    {
                        hit.collider.GetComponent<AI_Movement>().enabled = false;
                        cCooldown = 0f;
                        if (hit.collider.gameObject.tag == "Target" & !hit.collider.gameObject.transform.GetChild(1).gameObject.activeSelf)
                        {
                            /*game over*/

                            targetCount++;

                        }
                        if (hit.collider.gameObject.tag == "Crowd")
                        {
                            /*omaigod you shot a civilian, assassin wins*/
                            up1 = hit.collider.GetComponent<AI_Movement>().up1;
                            up2 = hit.collider.GetComponent<AI_Movement>().up2;
                            up3 = hit.collider.GetComponent<AI_Movement>().up3;
                            up4 = hit.collider.GetComponent<AI_Movement>().up4;

                            down1 = hit.collider.GetComponent<AI_Movement>().down1;
                            down2 = hit.collider.GetComponent<AI_Movement>().down2;
                            down3 = hit.collider.GetComponent<AI_Movement>().down3;
                            down4 = hit.collider.GetComponent<AI_Movement>().down4;

                            right1 = hit.collider.GetComponent<AI_Movement>().right1;
                            right2 = hit.collider.GetComponent<AI_Movement>().right2;
                            right3 = hit.collider.GetComponent<AI_Movement>().right3;
                            right4 = hit.collider.GetComponent<AI_Movement>().right4;

                            left1 = hit.collider.GetComponent<AI_Movement>().left1;
                            left2 = hit.collider.GetComponent<AI_Movement>().left2;
                            left3 = hit.collider.GetComponent<AI_Movement>().left3;
                            left4 = hit.collider.GetComponent<AI_Movement>().left4;
                        }
hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    
                    GetComponent<MeshRenderer>().material = kright2;
                }
                else if (knifeTimer < (knifeClock / 4f) * 3)
                {
                    GetComponent<MeshRenderer>().material = kright3;
                }
                else if (knifeTimer < (knifeClock / 4f) * 4)
                {
                    GetComponent<MeshRenderer>().material = kright4;
                }
            }
            else if (last == 1)
            {
                if (knifeTimer < (knifeClock / 8f))
                {
                    
                    GetComponent<MeshRenderer>().material = kleft1;
                }
                else if (knifeTimer < (knifeClock / 4f) * 2)
                {
                    if ((Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Vector3.right, out hit) & hit.distance < 1.5f))
                    {
                        hit.collider.GetComponent<AI_Movement>().enabled = false;
                        cCooldown = 0f;
                        if (hit.collider.gameObject.tag == "Target" & !hit.collider.gameObject.transform.GetChild(1).gameObject.activeSelf)
                        {
                            /*game over*/

                            targetCount++;

                        }
                        if (hit.collider.gameObject.tag == "Crowd")
                        {
                            /*omaigod you shot a civilian, assassin wins*/
                            up1 = hit.collider.GetComponent<AI_Movement>().up1;
                            up2 = hit.collider.GetComponent<AI_Movement>().up2;
                            up3 = hit.collider.GetComponent<AI_Movement>().up3;
                            up4 = hit.collider.GetComponent<AI_Movement>().up4;

                            down1 = hit.collider.GetComponent<AI_Movement>().down1;
                            down2 = hit.collider.GetComponent<AI_Movement>().down2;
                            down3 = hit.collider.GetComponent<AI_Movement>().down3;
                            down4 = hit.collider.GetComponent<AI_Movement>().down4;

                            right1 = hit.collider.GetComponent<AI_Movement>().right1;
                            right2 = hit.collider.GetComponent<AI_Movement>().right2;
                            right3 = hit.collider.GetComponent<AI_Movement>().right3;
                            right4 = hit.collider.GetComponent<AI_Movement>().right4;

                            left1 = hit.collider.GetComponent<AI_Movement>().left1;
                            left2 = hit.collider.GetComponent<AI_Movement>().left2;
                            left3 = hit.collider.GetComponent<AI_Movement>().left3;
                            left4 = hit.collider.GetComponent<AI_Movement>().left4;
                        }
hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    
                    GetComponent<MeshRenderer>().material = kleft2;
                }
                else if (knifeTimer < (knifeClock / 4f) * 3)
                {
                    GetComponent<MeshRenderer>().material = kleft3;
                }
                else if (knifeTimer < (knifeClock / 4f) * 4)
                {
                    GetComponent<MeshRenderer>().material = kleft4;
                }
            }
        }

        transform.position = new Vector3(transform.position.x, (transform.position.z + 20f) / 1000f, transform.position.z);
    }

    void runDown()
    {
        if (!knife)
        {
            if (animationTimer < animationClock / 4f)
            {
                GetComponent<MeshRenderer>().material = down1;
            }
            else if (animationTimer < (animationClock / 4f) * 2)
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
        else
        {
            if (knifeTimer < (knifeClock / 8f))
            {
            
                GetComponent<MeshRenderer>().material = kdown1;
            }
            else if (knifeTimer < (knifeClock / 4f) * 2)
            {
                if ((Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Vector3.forward, out hit) & hit.distance < 1.5f))
                {
                    hit.collider.GetComponent<AI_Movement>().enabled = false;
                    cCooldown = 0f;
                    if (hit.collider.gameObject.tag == "Target" & !hit.collider.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        /*game over*/

                        targetCount++;

                    }
                    if (hit.collider.gameObject.tag == "Crowd")
                    {
                        /*omaigod you shot a civilian, assassin wins*/
                        up1 = hit.collider.GetComponent<AI_Movement>().up1;
                        up2 = hit.collider.GetComponent<AI_Movement>().up2;
                        up3 = hit.collider.GetComponent<AI_Movement>().up3;
                        up4 = hit.collider.GetComponent<AI_Movement>().up4;

                        down1 = hit.collider.GetComponent<AI_Movement>().down1;
                        down2 = hit.collider.GetComponent<AI_Movement>().down2;
                        down3 = hit.collider.GetComponent<AI_Movement>().down3;
                        down4 = hit.collider.GetComponent<AI_Movement>().down4;

                        right1 = hit.collider.GetComponent<AI_Movement>().right1;
                        right2 = hit.collider.GetComponent<AI_Movement>().right2;
                        right3 = hit.collider.GetComponent<AI_Movement>().right3;
                        right4 = hit.collider.GetComponent<AI_Movement>().right4;

                        left1 = hit.collider.GetComponent<AI_Movement>().left1;
                        left2 = hit.collider.GetComponent<AI_Movement>().left2;
                        left3 = hit.collider.GetComponent<AI_Movement>().left3;
                        left4 = hit.collider.GetComponent<AI_Movement>().left4;
                    }
hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                
                GetComponent<MeshRenderer>().material = kdown2;
            }
            else if (knifeTimer < (knifeClock / 4f) * 3)
            {
                GetComponent<MeshRenderer>().material = kdown3;
            }
            else if (knifeTimer < (knifeClock / 4f) * 4)
            {
                GetComponent<MeshRenderer>().material = kdown4;
            }
        }



    }
    void runUp()
    {
        if (!knife)
        { 
            if (animationTimer < animationClock / 4f)
            {
                
                GetComponent<MeshRenderer>().material = up1;
            }
            else if (animationTimer < (animationClock / 4f) * 2)
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
        else
        {
            if (knifeTimer < (knifeClock / 8f))
            {

                GetComponent<MeshRenderer>().material = kup1;
            }
            else if (knifeTimer < (knifeClock / 4f) * 2)
            {
                if ((Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Vector3.back, out hit) & hit.distance < 1.5f))
                {
                    hit.collider.GetComponent<AI_Movement>().enabled = false;
                    cCooldown = 0f;
                    if (hit.collider.gameObject.tag == "Target" & !hit.collider.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        /*game over*/

                        targetCount++;

                    }
                    if (hit.collider.gameObject.tag == "Crowd")
                    {
                        /*omaigod you shot a civilian, assassin wins*/
                        up1 = hit.collider.GetComponent<AI_Movement>().up1;
                        up2 = hit.collider.GetComponent<AI_Movement>().up2;
                        up3 = hit.collider.GetComponent<AI_Movement>().up3;
                        up4 = hit.collider.GetComponent<AI_Movement>().up4;

                        down1 = hit.collider.GetComponent<AI_Movement>().down1;
                        down2 = hit.collider.GetComponent<AI_Movement>().down2;
                        down3 = hit.collider.GetComponent<AI_Movement>().down3;
                        down4 = hit.collider.GetComponent<AI_Movement>().down4;

                        right1 = hit.collider.GetComponent<AI_Movement>().right1;
                        right2 = hit.collider.GetComponent<AI_Movement>().right2;
                        right3 = hit.collider.GetComponent<AI_Movement>().right3;
                        right4 = hit.collider.GetComponent<AI_Movement>().right4;

                        left1 = hit.collider.GetComponent<AI_Movement>().left1;
                        left2 = hit.collider.GetComponent<AI_Movement>().left2;
                        left3 = hit.collider.GetComponent<AI_Movement>().left3;
                        left4 = hit.collider.GetComponent<AI_Movement>().left4;
                    }
hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                
                GetComponent<MeshRenderer>().material = kup2;
            }
            else if (knifeTimer < (knifeClock / 4f) * 3)
            {
                GetComponent<MeshRenderer>().material = kup3;
            }
            else if (knifeTimer < (knifeClock / 4f) * 4)
            {
                GetComponent<MeshRenderer>().material = kup4;
            }
        }
    }
    void runLeft()
    {
        if (!knife)
        {
            if (animationTimer < animationClock / 4f)
            {
                GetComponent<MeshRenderer>().material = left1;
            }
            else if (animationTimer < (animationClock / 4f) * 2)
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
        else
        {
            if (knifeTimer < (knifeClock / 8f))
            {

                GetComponent<MeshRenderer>().material = kleft1;
            }
            else if (knifeTimer < (knifeClock / 4f) * 2)
            {
                if ((Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Vector3.right, out hit) & hit.distance < 1.5f))
                {
                    hit.collider.GetComponent<AI_Movement>().enabled = false;
                    cCooldown = 0f;
                    if (hit.collider.gameObject.tag == "Target" & !hit.collider.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        /*game over*/

                        targetCount++;

                    }
                    if (hit.collider.gameObject.tag == "Crowd")
                    {
                        /*omaigod you shot a civilian, assassin wins*/
                        up1 = hit.collider.GetComponent<AI_Movement>().up1;
                        up2 = hit.collider.GetComponent<AI_Movement>().up2;
                        up3 = hit.collider.GetComponent<AI_Movement>().up3;
                        up4 = hit.collider.GetComponent<AI_Movement>().up4;

                        down1 = hit.collider.GetComponent<AI_Movement>().down1;
                        down2 = hit.collider.GetComponent<AI_Movement>().down2;
                        down3 = hit.collider.GetComponent<AI_Movement>().down3;
                        down4 = hit.collider.GetComponent<AI_Movement>().down4;

                        right1 = hit.collider.GetComponent<AI_Movement>().right1;
                        right2 = hit.collider.GetComponent<AI_Movement>().right2;
                        right3 = hit.collider.GetComponent<AI_Movement>().right3;
                        right4 = hit.collider.GetComponent<AI_Movement>().right4;

                        left1 = hit.collider.GetComponent<AI_Movement>().left1;
                        left2 = hit.collider.GetComponent<AI_Movement>().left2;
                        left3 = hit.collider.GetComponent<AI_Movement>().left3;
                        left4 = hit.collider.GetComponent<AI_Movement>().left4;
                    }
hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                
                GetComponent<MeshRenderer>().material = kleft2;
            }
            else if (knifeTimer < (knifeClock / 4f) * 3)
            {
                GetComponent<MeshRenderer>().material = kleft3;
            }
            else if (knifeTimer < (knifeClock / 4f) * 4)
            {
                GetComponent<MeshRenderer>().material = kleft4;
            }
        }
    }
    void runRight()
    {
        if (!knife)
        {
            if (animationTimer < animationClock / 8f)
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
        else
        {
            if (knifeTimer < (knifeClock / 8f))
            {

                GetComponent<MeshRenderer>().material = kright1;
            }
            else if (knifeTimer < (knifeClock / 4f) * 2)
            {
                if ((Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Vector3.left, out hit) & hit.distance < 1.5f))
                {
                    hit.collider.GetComponent<AI_Movement>().enabled = false;
                    cCooldown = 0f;
                    if (hit.collider.gameObject.tag == "Target"& !hit.collider.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        /*game over*/
                        
                        targetCount++;

                    }
                    if (hit.collider.gameObject.tag == "Crowd")
                    {
                        /*omaigod you shot a civilian, assassin wins*/
                        up1 = hit.collider.GetComponent<AI_Movement>().up1;
                        up2 = hit.collider.GetComponent<AI_Movement>().up2;
                        up3 = hit.collider.GetComponent<AI_Movement>().up3;
                        up4 = hit.collider.GetComponent<AI_Movement>().up4;

                        down1 = hit.collider.GetComponent<AI_Movement>().down1;
                        down2 = hit.collider.GetComponent<AI_Movement>().down2;
                        down3 = hit.collider.GetComponent<AI_Movement>().down3;
                        down4 = hit.collider.GetComponent<AI_Movement>().down4;

                        right1 = hit.collider.GetComponent<AI_Movement>().right1;
                        right2 = hit.collider.GetComponent<AI_Movement>().right2;
                        right3 = hit.collider.GetComponent<AI_Movement>().right3;
                        right4 = hit.collider.GetComponent<AI_Movement>().right4;

                        left1 = hit.collider.GetComponent<AI_Movement>().left1;
                        left2 = hit.collider.GetComponent<AI_Movement>().left2;
                        left3 = hit.collider.GetComponent<AI_Movement>().left3;
                        left4 = hit.collider.GetComponent<AI_Movement>().left4;
                    }
hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                
                GetComponent<MeshRenderer>().material = kright2;
            }
            else if (knifeTimer < (knifeClock / 4f) * 3)
            {
                GetComponent<MeshRenderer>().material = kright3;
            }
            else if (knifeTimer < (knifeClock / 4f) * 4)
            {
                GetComponent<MeshRenderer>().material = kright4;
            }
        }
    }
}
