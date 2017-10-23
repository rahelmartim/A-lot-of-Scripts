using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible_floor : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnCollisionEnter2D(Collision2D colisor)
    {
        
        if (colisor.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
       

    }
}
