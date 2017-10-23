using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atckcsad : MonoBehaviour {
    public GameObject oooo;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player_su")
        {
            oooo.SetActive(true);
        }
    }
}
