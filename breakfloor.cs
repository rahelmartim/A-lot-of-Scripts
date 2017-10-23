using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakfloor : MonoBehaviour {
    private bool emCima = false;
    public GameObject boxPrefab;
    public GameObject player;
    private GameObject criado = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Action") && emCima)
        {
            if (player.GetComponent<Player>().givePicareta)
            {
                criado.GetComponent<GUIText>().text = "Quebrando........";
                Destroy(gameObject, 1f);
                Destroy(criado, 1f);
            }
            else
            {
                criado.GetComponent<GUIText>().text = "Voce precisa de uma picareta !";
            }
        }
	}

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            boxPrefab.GetComponent<GUIText>().text = "Aperte E para quebrar !";
            criado = Instantiate(boxPrefab);
        }
        
    }
    
    void OnCollisionStay2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
           emCima = true;
        }
    }
    void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            emCima = false;
            Destroy(criado, 0.4f);
        }
    }
}
