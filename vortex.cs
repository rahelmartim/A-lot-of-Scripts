using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vortex : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {

		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        if (collision.gameObject.tag == "Player")
        {
            if (cam.GetComponent<camera>().key >= 10) Application.LoadLevel("win"); 
            else print("não tem 10 tickets");
        }
    }
    

}
