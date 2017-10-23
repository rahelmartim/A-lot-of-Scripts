using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabana : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<player>().key) Application.LoadLevel("win");
        }
        
    }
}
