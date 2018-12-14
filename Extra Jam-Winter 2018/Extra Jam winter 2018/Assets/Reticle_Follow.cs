using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle_Follow : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            transform.position = Vector3.Lerp(
                new Vector3(transform.position.x, 10, transform.position.z),
                new Vector3(hit.point.x, 10, hit.point.z),
                0.04f);
        }
        

        
    }
}
