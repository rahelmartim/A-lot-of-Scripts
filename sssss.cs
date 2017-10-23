using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sssss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel("scene");
        }	
	}


}
