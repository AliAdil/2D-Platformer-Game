using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //The Player's speed
    public float speed = 10.0f;

    //Game boundries
    private float leftwall = -4f;
    private float rightwall = 4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // get the horizontal axis that by default is bound  to the arrow key 
        // the value is in the range to -1 to 1 
        // make it move per second instead of frames
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // Move along the object's x-axis within the floor boinds
        if (transform.position.x + translation < rightwall && transform.position.x + translation > leftwall)
            transform.Translate(translation, 0, 0); 		
	}
}
