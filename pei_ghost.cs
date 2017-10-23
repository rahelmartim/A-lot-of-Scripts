using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pei_ghost : MonoBehaviour {
    //speed of projectile
    public float speed;
    // Use this for initialization
    public GameObject end_expl;
    public Transform explode_point;
    public float force;
    void Start () {
        Destroy(gameObject, 2f);
    }
	
	// Update is called once per frame
	void Update () {
        //Movement of projectile
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    //check if touch the player
    void OnCollisionEnter2D(Collision2D colisor)
    {   //if the player
        //take damage
        if (colisor.gameObject.tag == "Player")
        {
            var player_hp = colisor.gameObject.transform.GetComponentInChildren<hp>();
            var player = colisor.gameObject;
            if (player.GetComponent<Transform>().position.x < transform.position.x)
            {

                if (player.GetComponent<Isayah>().state == false)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
                }
                else if (player.GetComponent<Isayah>().state == true)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
                }
            }
            else
            {
                if (player.GetComponent<Isayah>().state == false)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
                }
                else if (player.GetComponent<Isayah>().state == true)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
                }
            }

            player_hp.lose_life();
        }
        if (colisor.gameObject.tag != "enemy")
        {
            Destroy(gameObject);
            Instantiate(end_expl, explode_point.position, transform.rotation);
        }

    }
}
