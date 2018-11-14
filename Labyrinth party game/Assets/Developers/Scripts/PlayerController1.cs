using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController1 : MonoBehaviour
{

    public float moveSpeed;

    public XboxController PlayerNumber;
    public float RotationSpeed;
    private Rigidbody PlayerRigid;

    private Vector3 MoveInput;
    private Vector3 MoveVelocity;
    private Vector3 TurnInput;

    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Animator CharacterAnim;
    [SerializeField]
    private MeshRenderer HammerObj;

    float ReverseControls;


    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody>();
        //MainCamera = FindObjectOfType<Camera>();
        CharacterAnim = GetComponent<Animator>();

        CharacterAnim.SetBool("IfIdle", true);

        Cursor.visible = false;

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (moveSpeed >= 15)
        {
            moveSpeed = 15;
        }
        if (CharacterAnim.GetBool("IfAttack") == true)
        {
            CharacterAnim.SetBool("IfIdle", false);
            CharacterAnim.SetBool("IfWalking", false);
            HammerObj.enabled = true;
        }
        if (CharacterAnim.GetBool("IfWalking") == true)
        {
            CharacterAnim.SetBool("IfIdle", false);
            CharacterAnim.SetBool("IfAttack", false);
            HammerObj.enabled = false;
        }
        if (CharacterAnim.GetBool("IfIdle") == true)
        {
            CharacterAnim.SetBool("IfWalking", false);
            CharacterAnim.SetBool("IfAttack", false);
            HammerObj.enabled = false;
        }
        if (XCI.GetAxisRaw(XboxAxis.LeftStickX, PlayerNumber) >= 0.5 || XCI.GetAxisRaw(XboxAxis.LeftStickX, PlayerNumber) <= -0.5)
        {
            CharacterAnim.SetBool("IfWalking", true);
            CharacterAnim.SetBool("IfIdle", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            CharacterAnim.SetBool("IfIdle", true);
            CharacterAnim.SetBool("IfWalking", false);
        }
        if (XCI.GetAxisRaw(XboxAxis.LeftStickY, PlayerNumber) >= 0.5 || XCI.GetAxisRaw(XboxAxis.LeftStickY, PlayerNumber) <= -0.5)
        {
            CharacterAnim.SetBool("IfWalking", true);
            CharacterAnim.SetBool("IfIdle", false);
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            CharacterAnim.SetBool("IfIdle", true);
            CharacterAnim.SetBool("IfWalking", false);
        }

        if (moveSpeed <= 5 && moveSpeed >= 1)
        {
            moveSpeed = 5;
        }

        MoveInput.x = XCI.GetAxis(XboxAxis.LeftStickX, PlayerNumber);
        MoveInput.z = XCI.GetAxis(XboxAxis.LeftStickY, PlayerNumber);
        TurnInput.y += XCI.GetAxis(XboxAxis.RightStickX, PlayerNumber) * RotationSpeed;
        transform.rotation = Quaternion.Euler(TurnInput);

        if (ReverseControls >= 0)
        {
            MoveInput = -MoveInput;
            ReverseControls -= Time.deltaTime;
        }

        if (XCI.GetButtonDown(XboxButton.RightBumper, PlayerNumber) || XCI.GetButtonDown(XboxButton.LeftBumper, PlayerNumber))
        {
            CharacterAnim.SetBool("IfAttack", true);
            CharacterAnim.SetBool("IfIdle", false);
        }
        //else if (XCI.GetButtonDown(XboxButton.RightBumper) || XCI.GetButton(XboxButton.LeftBumper))
        //{
        //    CharacterAnim.SetBool("IfAttack", false);
        //}
        MoveVelocity = MoveInput * moveSpeed;

    }

    public void StopAttack()
    {
        CharacterAnim.SetBool("IfAttack", false);
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
