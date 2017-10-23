using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    //Player for follow
    public Transform player;
    //Tecnical adjust for the camera position
    public float adjustX;
    public float adjustY;
    public float adjustTime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = new Vector3(player.position.x + adjustX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime + adjustTime);
    }
}
