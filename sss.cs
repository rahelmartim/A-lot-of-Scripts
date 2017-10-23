using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sss : MonoBehaviour {
    public float force;
    
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 2f);

        GetComponent<Rigidbody2D>().AddForce(Vector2.right * this.force);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<ninja>().invunerable == false)
            {
                collision.gameObject.GetComponent<ninja>().takeDamage();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
