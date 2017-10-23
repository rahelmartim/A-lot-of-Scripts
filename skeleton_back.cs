using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton_back : MonoBehaviour
{

    private GameObject player;
    public float force;
    public Animator anim_control;
    public GameObject skeleton_dead;
    public Vector3 adjust;
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
        if (colisor.gameObject.tag == "Player")
        {
            anim_control.SetTrigger("atck");
            if (player.GetComponent<Isayah>().state == false)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            }
            else if (player.GetComponent<Isayah>().state == true)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            }
            colisor.gameObject.GetComponentInChildren<hp>().lose_life();
        }
        else if (colisor.gameObject.tag == "fireball" || colisor.gameObject.tag == "ghostball")
        {
            if (!GetComponentInParent<skeleton>().dead)
            {
                var distancia = (colisor.transform.position.x - transform.position.x);
                //if (colisor.gameObject.GetComponent<Transform>().position.x < transform.position.x)
                if (distancia < 0)
                {
                    GetComponentInParent<skeleton>().dead = true;
                    GetComponentInParent<skeleton>().dead_h();
                    Instantiate(skeleton_dead, transform.position + adjust, transform.rotation);
                }
                else
                {
                    GetComponentInParent<skeleton>().dead = true;
                    GetComponentInParent<skeleton>().dead_h();
                    Instantiate(skeleton_dead, transform.position + adjust, new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w));
                }
            }

        }
    }
}
