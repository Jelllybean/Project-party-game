using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody PlayerRigid;

    private Vector3 MoveInput;
    private Vector3 MoveVelocity;

    [SerializeField]
    private Camera MainCamera;

    float ReverseControls;

    
	void Start ()
    {
        PlayerRigid = GetComponent<Rigidbody>();
        //MainCamera = FindObjectOfType<Camera>();


        Cursor.visible = false;

        Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
       if(moveSpeed >= 15)
       {
            moveSpeed = 15;
       }
       if(moveSpeed <= 5)
        {
            moveSpeed = 5;
        }

        MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        if(ReverseControls >= 0)
        {
            MoveInput = -MoveInput;
            ReverseControls -= Time.deltaTime;
        }
              
        
        MoveVelocity = MoveInput * moveSpeed;

        Ray CameraRay = MainCamera.ScreenPointToRay(Input.mousePosition);

        Plane worldPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (worldPlane.Raycast(CameraRay, out rayLength))
        {
            Vector3 pointToLook = CameraRay.GetPoint(rayLength);
            Debug.DrawLine(CameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

    }

    private void FixedUpdate()
    {
        PlayerRigid.velocity = MoveVelocity;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Reverser")
        {
            ReverseControls = 2f;
        }
    }
}
