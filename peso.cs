using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peso : MonoBehaviour {
    public bool active;
	// Use this for initialization
	void Start () {
        active = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!active)
            {
                if (collision.gameObject.GetComponent<ninja>().invunerable == false)
                {
                    collision.gameObject.GetComponent<ninja>().takeDamage();
                    active = true;
                }
            }
       

        }
    }
}
