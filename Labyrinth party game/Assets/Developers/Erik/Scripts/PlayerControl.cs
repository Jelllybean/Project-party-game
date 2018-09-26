using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    Vector3 movement;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        movement.z = -Input.GetAxisRaw("Horizontal");
        movement.x = Input.GetAxisRaw("Vertical");
        transform.position += movement * Time.deltaTime * 4;
	}
}
