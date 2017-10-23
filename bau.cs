using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bau : MonoBehaviour {
    public GameObject boxPrefab;
    private bool emCima = false;
    private GameObject criado;
    public GameObject player;
    public GameObject escada;
    private bool pegou = false;
    private bool invocou = false;
    public AudioSource backmusic;
    public AudioClip final;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (pegou && !emCima && !invocou)
        {
            Instantiate(escada);
            Destroy(gameObject, 2f);
            invocou = true;
        }
        if (Input.GetButtonDown("Action") && emCima && !pegou)
        {
            if (player.GetComponent<Player>().diamondsCollec >= 10)
            {
                criado.GetComponent<GUIText>().text = "Voce pegou a picareta";
                player.GetComponent<Player>().givePicareta = true;
                player.GetComponent<Player>().gainLife(100);
                pegou = true;
                backmusic.Stop();
                backmusic.clip = final;
                backmusic.Play();
                backmusic.volume = 1;
            }
            else
            {
                criado.GetComponent<GUIText>().text = "Voce precisa de 10 diamantes";
            }

        }
        

    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            boxPrefab.GetComponent<GUIText>().text = "Aperte E para abrir !";
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
