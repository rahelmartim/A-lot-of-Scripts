using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {
    private const bool UP = true, RIGHT = true, DOWN = false, LEFT = false;
    

    private float time_up;
    public float total_time;
    public float steap_anim_0;
    private bool state_anim_0;

 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time_up+= Time.deltaTime;
        if (time_up >= total_time)
        {
            state_anim_0 = !state_anim_0;
            time_up = 0;
        }

        if (state_anim_0 == UP) GetComponent<Transform>().Translate(Vector2.up * steap_anim_0 * Time.deltaTime);
        else GetComponent<Transform>().Translate(Vector2.down * steap_anim_0 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (colisor.gameObject.tag == "Player")
        {
            colisor.gameObject.GetComponentInChildren<hp>().lava();
            colisor.gameObject.GetComponent<Isayah>().die();
        }
    }
}
