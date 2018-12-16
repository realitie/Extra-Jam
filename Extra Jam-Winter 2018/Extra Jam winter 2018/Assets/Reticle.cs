using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {

    private bool check = false;
    private bool shoot = false;
    private float cCooldown = 10f;
	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {

        if (Input.GetMouseButton(0) & cCooldown > 10f)
        {
            check = true;
        }
        if (Input.GetMouseButton(1))
        {
            shoot = true;
        }
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
                5f*Time.fixedDeltaTime);
            if (check)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    /*add check animation here*/

                    cCooldown = 0f;
                    check = false;
                }
                else if (hit.collider.gameObject.tag == "Crowd")
                {
                    /*add check animation here*/
                    cCooldown = 0f;
                    check = false;
                }
            }
        }
        

        if (shoot)
        {
            shoot = false;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    /*game over*/
                }
                if (hit.collider.gameObject.tag == "Crowd")
                {
                    /*omaigod you shot a civilian, assassin wins*/
                }
            }
                
        }
        
    }
}
