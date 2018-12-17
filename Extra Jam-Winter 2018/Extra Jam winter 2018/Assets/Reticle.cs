using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {


    private bool shoot = false;
    private float cCooldown = 0f;
    public bool gameOver = false;

    public GameObject assassinWin;
    public GameObject sniperWin;
    GameObject reveal;
	// Use this for initialization
	void Start () {
		
	}

    private void Update()

    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        if (cCooldown<= 8f)
        cCooldown = cCooldown + Time.deltaTime;
        if (cCooldown > 8f)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            if (Input.GetMouseButton(0))
            {
                shoot = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))

        {
            transform.position = Vector3.MoveTowards(
                new Vector3(transform.position.x, 10, transform.position.z),
                new Vector3(hit.point.x, 10, hit.point.z),
                5.5f*Time.fixedDeltaTime);
            /*if (check)
            {
                    
                    reveal = hit.collider.gameObject.transform.GetChild(0).gameObject;
                    reveal.SetActive(true);
                

                    cCooldown = 0f;
                    check = false;

            }*/
        }
        

        if (shoot)
        {
            shoot = false;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.collider.gameObject.tag == "Player"& !gameOver)
                {
                    /*game over*/
                    hit.collider.GetComponent<Assassin_Control>().enabled = false;
                    hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    sniperWin.SetActive(true);
                    gameOver = true;
                }
                if (hit.collider.gameObject.tag == "Crowd")
                {
                    /*omaigod you shot a civilian, assassin wins*/
                    hit.collider.GetComponent<AI_Movement>().enabled = false;
                    hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);

                }
            }
                
        }

        
        
    }
}
