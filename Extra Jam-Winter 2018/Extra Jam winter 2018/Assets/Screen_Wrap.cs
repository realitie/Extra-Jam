using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Wrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerExit(Collider other)
    {
      
            other.transform.position = new Vector3(other.transform.position.x * (-1f), other.transform.position.y, other.transform.position.z * (-1f));
      
        
    }
}
