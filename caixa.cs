using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caixa : MonoBehaviour {

    public enum type { explosion, enemy, buff, nothing}
    public type caixa_type;
    public GameObject[] buff, trap;
    private float elpsed;
    private bool active;
    public GameObject enemy;
    
    // Use this for initialization
    void Start ()
    {
        active = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (active)
        {
            if (caixa_type == type.buff)
            {
                GetComponent<Animator>().SetTrigger("item");
                elpsed += Time.deltaTime;
                if (elpsed >= 1.5f)
                {
                    float index = Random.Range(0, 10);
                    int true_index = 0;
                    if (index <= 1.5f)
                    {
                        true_index = 0;
                    }
                    else if (index <= 3f)
                    {
                        true_index = 1;
                    }
                    else if (index <= 4.5f)
                    {
                        true_index = 2;
                    }
                    else if (index <= 6)
                    {
                        true_index = 3;
                    }
                    else if (index <= 7.5f)
                    {
                        true_index = 4;
                    }
                    else
                    {
                        true_index = 5;
                    }

                    Instantiate(buff[true_index], transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
            else if (caixa_type == type.enemy)
            {
                GetComponent<Animator>().SetTrigger("alert");
                elpsed += Time.deltaTime;
                if (elpsed >= 1.5f)
                {

                    Instantiate(enemy, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
            else if (caixa_type == type.explosion)
            {
                GetComponent<Animator>().SetTrigger("alert");
                elpsed += Time.deltaTime;
                if (elpsed >= 1.5f)
                {
                    float index = Random.Range(0, 10);
                    int true_index = 0;
                    if (index <= 2.5f)
                    {
                        true_index = 0;
                    }
                    else if (index <= 5f)
                    {
                        true_index = 1;
                    }
                    else if (index <= 7.5f)
                    {
                        true_index = 2;
                    }
                    else
                    {
                        true_index = 3;
                    }
                   

                    Instantiate(trap[true_index], transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player_su" || collision.gameObject.tag == "player_su_put" || collision.gameObject.tag == "player_su_mat"
            || collision.gameObject.tag == "player_su_life" || collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.tag != "Player")
            {
                           Destroy(collision.gameObject);
            
            }
 
            active = true;

        }
        else if (collision.gameObject.tag == "player_su_resi")
        {
            Destroy(gameObject);
            active = true;
        }
    }
}
