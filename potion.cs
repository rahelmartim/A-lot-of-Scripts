using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour {
    private GameObject player;

    private const bool UP = true, RIGHT = true, DOWN = false, LEFT = false;

    public int type_anim;

    private float time_up_anim_0;
    public float total_time_anim_0;
    public float steap_anim_0;
    private bool state_anim_0;

    private float time_right_anim_1;
    public float total_time_anim_1;
    public float steap_anim_1;
    private bool state_anim_1;

    // Use this for initialization
    void Start ()
    {
        this.state_anim_0 = UP;
        this.state_anim_1 = RIGHT;
        type_anim = Random.Range(0, 2);
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (this.type_anim == 0) anim_0();
        else                     anim_1();

        if (player.GetComponent<Isayah>().state == false) transform.eulerAngles = new Vector2(0, 0);
        else transform.eulerAngles = new Vector2(0, 180);
    }

    void anim_0()
    {
        time_up_anim_0 += Time.deltaTime;
        if (time_up_anim_0 >= total_time_anim_0)
        {
            state_anim_0 = !state_anim_0;
            time_up_anim_0 = 0;
        }

        if (state_anim_0 == UP) GetComponent<Transform>().Translate(Vector2.up * steap_anim_0 * Time.deltaTime);
        else                    GetComponent<Transform>().Translate(Vector2.down * steap_anim_0 * Time.deltaTime);
    }

    void anim_1()
    {
        time_right_anim_1 += Time.deltaTime;
        if (time_right_anim_1 >= total_time_anim_1)
        {
            state_anim_1 = !state_anim_1;
            time_right_anim_1 = 0;
        }

        if (state_anim_1 == RIGHT) GetComponent<Transform>().Rotate(0,0,steap_anim_1);
        else                       GetComponent<Transform>().Rotate(0,0,-steap_anim_1);

    }

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (colisor.gameObject.tag == "Player")
        {   //Add a force, to jump the player
            colisor.gameObject.GetComponentInChildren<hp>().gain_life();
            print("HEAL xD");
            Destroy(gameObject);

        }
    }

}
