using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataaaa : MonoBehaviour {
    public GameObject oooo;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player_su")
        {
            oooo.SetActive(true);
        }
    }
}
