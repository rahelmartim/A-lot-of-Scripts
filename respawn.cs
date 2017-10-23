using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {
    //Prefab fireball
    public GameObject objeto;
    //Time to respawn the fireball
    public float respawnTime = 0f;
    //elapsed time to last fireball
    private float elapsedTime = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= respawnTime)
        {
            Instantiate(objeto, transform.position, objeto.transform.rotation);
            elapsedTime = 0f;
        }
    }
}
