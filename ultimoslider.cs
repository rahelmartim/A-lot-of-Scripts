using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultimoslider : MonoBehaviour {
    private bool ativate = false;
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        if (ativate)
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            ativate = true;
        }
    }
}
