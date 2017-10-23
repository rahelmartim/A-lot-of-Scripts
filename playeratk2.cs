using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeratk2 : MonoBehaviour {
    //speed of projectile
    public float speed;
    // Use this for initialization

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement of projectile
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    //check if touch the player
    void OnCollisionEnter2D(Collision2D colisor)
    {   //if the player
        //take damage
        if (colisor.gameObject.tag == "enemy")
        {
            Destroy(colisor.gameObject);
        }
        if (colisor.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
