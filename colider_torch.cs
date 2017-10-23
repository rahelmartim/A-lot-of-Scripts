using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colider_torch : MonoBehaviour {
    public Transform point;
    public GameObject burn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (colisor.gameObject.tag == "Player")
        {
            if(GetComponentInParent<torch>().burned_on == false)
            {
                Instantiate(burn, point.position, point.rotation);
                GetComponentInParent<torch>().burned_on = true;
            }
            
        }
    }
}
