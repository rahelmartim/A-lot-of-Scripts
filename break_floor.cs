using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_floor : MonoBehaviour
{
    public GameObject player, b_anim, b_anim_f;
    public Transform normal_p, invert_point;
    public bool final = false;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "fireball")
        {
            if (!player.GetComponent<Isayah>().state)
            {
                Destroy(gameObject);
                Instantiate(this.b_anim, normal_p.position, normal_p.rotation);
            }
            else
            {
                Destroy(gameObject);
                Instantiate(this.b_anim_f, invert_point.position, invert_point.rotation);
            }
            

        }
        if (final)
        {
            if (colisor.gameObject.tag == "Player")
            {
                colisor.gameObject.GetComponentInChildren<hp>().lose_life();
            }
            if(colisor.gameObject.tag == "Boss")
            {
                if (!colisor.gameObject.GetComponentInChildren<SpriteRenderer>().flipX)
                {
                    Destroy(gameObject);
                    Instantiate(this.b_anim, normal_p.position, normal_p.rotation);
                }
                else
                {
                    Destroy(gameObject);
                    Instantiate(this.b_anim_f, invert_point.position, invert_point.rotation);
                }
            }
        }
        


    }

}
