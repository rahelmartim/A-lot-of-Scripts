using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chama_c : MonoBehaviour {
    public int bomb_pos;
    public float force;
    // Use this for initialization
    void Start () {
        if (bomb_pos == 1)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }
        else if (bomb_pos == 2)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        }
        else if (bomb_pos == 3)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        }
        else if (bomb_pos == 4)
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
        if (collision.gameObject.tag != "bomba")
        {
            
            Destroy(gameObject);
        }
        
    }
}
