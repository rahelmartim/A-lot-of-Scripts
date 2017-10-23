using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour {
    private bool emCima = false;
    private bool inside = false;
    public GameObject Player;
    public Transform point;
    public GameObject boxPrefab;
    private GameObject criado;
    private bool active = false;
    public float newZ;
    public float timerotate;
    public float force;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (inside)
        {
            Player.transform.position = point.position;
            active = true;
        }

        if (Input.GetButtonDown("Action") && emCima)
        {
            inside = true;
        }

        if (active)
        {
            gameObject.transform.Rotate(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y,newZ ), timerotate);
        }
        if (active && inside)
        {
            if (Input.GetButtonDown("Action"))
            {
                Player.GetComponent<Rigidbody2D>().AddForce(transform.up * force * Time.deltaTime);
                inside = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            boxPrefab.GetComponent<GUIText>().text = "Aperte E para entrar !";
            criado = Instantiate(boxPrefab);
        }

    }

    void OnTriggerStay2D(Collider2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            emCima = true;
        }
    }
    void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            emCima = false;
            Destroy(criado, 0.4f);
        }
    }
}
