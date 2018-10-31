using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour {

    public float moveSpeed;
    public XboxController PlayerNumber;
    public float RotationSpeed;
    private Rigidbody PlayerRigid;

    private Vector3 MoveInput;
    private Vector3 MoveVelocity;
    private Vector3 TurnInput;

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

        MoveInput.x = XCI.GetAxis(XboxAxis.LeftStickX, PlayerNumber);
        MoveInput.z = XCI.GetAxis(XboxAxis.LeftStickY, PlayerNumber);
        TurnInput.y += XCI.GetAxis(XboxAxis.RightStickX, PlayerNumber) * RotationSpeed;
        transform.rotation = Quaternion.Euler(TurnInput);
        
        if(ReverseControls >= 0)
        {
            MoveInput = -MoveInput;
            ReverseControls -= Time.deltaTime;
        }

        MoveVelocity = MoveInput * moveSpeed;
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
