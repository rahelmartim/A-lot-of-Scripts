using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
    private bool range;
    public GameObject ninja;
    public float time;
    private float elapsed;
	// Use this for initialization
	void Start () {
        range = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (range)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= time)
            {
                elapsed = 0;
                Instantiate(ninja, transform.position, transform.rotation);
                GetComponent<Animator>().SetTrigger("open");
            }
        }
    
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            range = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            range = false;
        }
    }
}
