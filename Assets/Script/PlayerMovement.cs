using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //The Player's speed
    public float speed = 10.0f;
    private Animator anim;

    //Game boundries
    private float leftwall = -2f;
    private float rightwall = 2f;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        // get the horizontal axis that by default is bound  to the arrow key 
        // the value is in the range to -1 to 1 
        // make it move per second instead of frames
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //change direction if need 
        if (translation > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (translation < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        Debug.Log("Translation " + translation + " = " + "Input.GetAxis Horizontal " + Input.GetAxis("Horizontal") + " * Speed " + speed + " *Time.deltaTime " +Time.deltaTime);
        // Move along the object's x-axis within the floor boinds
        if (transform.position.x + translation < rightwall && transform.position.x + translation > leftwall)
        { transform.Translate(translation, 0, 0); }		

        // Switching between iddle and walk states in animator 
        if (translation != 0)
        {
            anim.SetFloat("PlayerSpeed", speed);
        }
        else
        {
            anim.SetFloat("PlayerSpeed", 0);
        }

        // swtiching between Jump and Walk animation
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Jump", !(anim.GetBool("Jump")));
        }
	}
}
