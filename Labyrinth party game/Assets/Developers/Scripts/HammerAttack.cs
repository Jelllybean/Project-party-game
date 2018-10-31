using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour {

    [SerializeField]
    private PlayerController1[] playerController;
    private MeshCollider Collider;

    private void Start()
    {
        Collider = GetComponent<MeshCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player 1")
        {
            playerController[0].moveSpeed = 0;
            StartCoroutine(ReturnMovement(0));
        }
        if(other.gameObject.name == "Player 2")
        {
            playerController[1].moveSpeed = 0;
            StartCoroutine(ReturnMovement(1));
        }
        if (other.gameObject.name == "Player 3")
        {
            playerController[2].moveSpeed = 0;
            StartCoroutine(ReturnMovement(2));
        }
        if (other.gameObject.name == "Player 4")
        {
            playerController[3].moveSpeed = 0;
            StartCoroutine(ReturnMovement(3));
        }
    }
    IEnumerator ReturnMovement(int player)
    {
        yield return new WaitForSeconds(3f);
        playerController[player].moveSpeed = 10;
    }
    public void ActivateCollider()
    {
        Collider.isTrigger = true;
    }
    public void DisableCollider()
    {
        Collider.isTrigger = false;
    }
}
