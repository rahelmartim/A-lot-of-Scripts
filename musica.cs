using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica : MonoBehaviour {
    public Texture2D musicOn;
    public Texture2D musicOff;
    public bool ativo;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {      
        if (ativo)
        {
            gameObject.GetComponent<AudioSource>().mute = false;
            gameObject.GetComponent<GUITexture>().texture = musicOn;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().mute = true;
            gameObject.GetComponent<GUITexture>().texture = musicOff;
        }
    }
    void OnMouseDown()
    {
        ativo = !ativo;
    }

}
