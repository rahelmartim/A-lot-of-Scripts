using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chama : MonoBehaviour {
    private enum type {cima, esq, dir, dia_e, dia_d}
    public float force;
	// Use this for initialization
	void Start ()
    {
        float index = Random.Range(0, 10);
      
        if (index <= 2f)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }
        else if (index <= 4f)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        }
        else if (index <= 6f)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        }
        else if(index <= 8f)
        {
            GetComponent<Rigidbody2D>().AddForce((Vector2.up + Vector2.left) * force);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce((Vector2.up + Vector2.right) * force);
        }

        Destroy(gameObject, 5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (collision.gameObject.GetComponent<ninja>().invunerable == false)
            {
               collision.gameObject.GetComponent<ninja>().takeDamage();
               
            }
            


        }
        Destroy(gameObject);
    }
}
