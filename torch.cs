using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour {
    public bool burned_on;
    public Animator anim_control;
    public GameObject burn;
    public Transform torch_point;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (colisor.gameObject.tag == "burn")
        {
            anim_control.SetTrigger("burn");
        }
        if (!burned_on)
        {
            if (colisor.gameObject.tag == "fireball")
            {
                anim_control.SetTrigger("burn");
                burned_on = true;
            }
        }
        else
        {
            if (colisor.gameObject.tag == "ghostball")
            {
                anim_control.SetTrigger("fant");
                burned_on = false;
            }
        }
        
    }




}
