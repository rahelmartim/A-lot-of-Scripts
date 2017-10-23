using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamanho : MonoBehaviour {

	public float tempo, passo;
	private float tempoPassado;
	private bool estado;

	// Use this for initialization
	void Start () {
		estado = false;
	}
	
	// Update is called once per frame
	void Update () {
		tempoPassado += Time.deltaTime;
		if (tempoPassado > tempo) {
			tempoPassado = 0;
			estado = !estado;
		}
		if (estado) {
			GetComponent<Transform>().localScale += new Vector3(passo, passo, passo);
        } else {
			GetComponent<Transform>().localScale += new Vector3(-passo, -passo, -passo);
		}
	}
}
