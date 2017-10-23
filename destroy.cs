using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {
    public float time_d;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, time_d);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
