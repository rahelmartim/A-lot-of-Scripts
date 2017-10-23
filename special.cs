using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //if touch a enemy, detroy it
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "enemy")
        {
            Destroy(colisor.gameObject);
        }
    }
}
