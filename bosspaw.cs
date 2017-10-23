using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosspaw : MonoBehaviour {
    public GameObject boss;
    private bool active;
	// Use this for initialization
	void Start () {
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !active)
        {
            active = true;
            Instantiate(boss, transform.position, transform.rotation);
        }
    }
}
