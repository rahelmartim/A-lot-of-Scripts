using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour {
    //consts
    const bool INC = true;
    const bool DEC = false;
    //def the minimum range of the light
    public float min_range;
    //def the maximum range of the light
    public float max_range;
    //def the state of light, Increasing or decreasing
    private bool state;
    //size of step
    public float step;
    public float step_puto;
    private bool puto;
    private bool is_player;
	// Use this for initialization
	void Start ()
    {
        this.state = INC;
        this.is_player = (gameObject.tag == "Player");

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (is_player)
        {
            //check if the player is puto
            this.puto = GetComponentInParent<Isayah>().time_stoped >= GetComponentInParent<Isayah>().time_puto;
            //Move the light
            if (!this.puto)
            {
                if (this.state == INC) GetComponent<Light>().range += this.step;
                else if (this.state == DEC) GetComponent<Light>().range -= this.step;
            }
            else
            {
                if (this.state == INC) GetComponent<Light>().range += this.step_puto;
                else if (this.state == DEC) GetComponent<Light>().range -= this.step_puto;
            }
        }
        else
        {
            if (this.state == INC) GetComponent<Light>().range += this.step;
            else if (this.state == DEC) GetComponent<Light>().range -= this.step;
        }
      
       
        //Verify of ends
        if (GetComponent<Light>().range >= this.max_range || GetComponent<Light>().range <= this.min_range) this.state = !this.state;

    }
}
