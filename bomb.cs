using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
    public float force;
    private float elapsed;
    public GameObject[] chama;
    public Transform[] pos;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce((Vector2.left + Vector2.up) * force);
        
    }
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        if(elapsed >= 2f)
        {
            Instantiate(chama[0], pos[0].position, transform.rotation);
            Instantiate(chama[1], pos[1].position, transform.rotation);
            Instantiate(chama[2], pos[2].position, transform.rotation);
            Instantiate(chama[3], pos[3].position, transform.rotation);
            Instantiate(chama[4], pos[4].position, transform.rotation);
            Destroy(gameObject);
        }
	}
}
