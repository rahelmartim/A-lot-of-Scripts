using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuvem : MonoBehaviour
{

    public float speed;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 20f);
        speed = Random.Range(1, 4);
        GetComponent<SpriteRenderer>().sortingOrder = Random.Range(0, 4);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.right * (speed/2) * Time.deltaTime);
	}
}
