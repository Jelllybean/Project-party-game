using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class HammerAttack : MonoBehaviour
{

    [SerializeField]
    private PlayerController1[] playerController;
    private BoxCollider Collider;
    [SerializeField]
    private Animator animation;
    [SerializeField]
    private ParticleSystem[] starParticle;

    public XboxController PlayerNumber;

    private void Start()
    {
        Collider = GetComponent<BoxCollider>();
        animation = GetComponent<Animator>();
    }
    private void Update()
    {
        if(XCI.GetButtonDown(XboxButton.RightBumper, PlayerNumber))
        {
            animation.SetBool("ifPressed", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1")
        {
            playerController[0].moveSpeed = 0;
            playerController[0].RotationSpeed = 0;
            StartCoroutine(ReturnMovement(0));
            starParticle[0].Play();
        }
        if (other.gameObject.name == "Player 2")
        {
            playerController[1].moveSpeed = 0;
            playerController[1].RotationSpeed = 0;
            StartCoroutine(ReturnMovement(1));
            starParticle[1].Play();
        }
        if (other.gameObject.name == "Player 3")
        {
            playerController[2].moveSpeed = 0;
            playerController[2].RotationSpeed = 0;
            StartCoroutine(ReturnMovement(2));
            starParticle[2].Play();
        }
        if (other.gameObject.name == "Player 4")
        {
            playerController[3].moveSpeed = 0;
            playerController[3].RotationSpeed = 0;
            StartCoroutine(ReturnMovement(3));
            starParticle[3].Play();
        }
    }
    IEnumerator ReturnMovement(int player)
    {
        yield return new WaitForSeconds(3f);
        playerController[player].moveSpeed = 10;
        playerController[player].RotationSpeed = 10;
        starParticle[player].Stop();
    }
    public void ActivateCollider()
    {
        Collider.enabled = true;
    }
    public void DisableCollider()
    {
        Collider.enabled = false;
    }
    public void StopAnimation()
    {
        animation.SetBool("ifPressed", false);
    }
}
