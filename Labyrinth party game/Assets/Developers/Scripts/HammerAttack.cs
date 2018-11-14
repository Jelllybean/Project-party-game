using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{

    [SerializeField]
    private PlayerController1[] playerController;
    [SerializeField]
    private ParticleSystem[] starParticles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1")
        {
            OnHit(0);
            ReturnMovement(0);
        }
        if (other.gameObject.name == "Player 2")
        {
            OnHit(1);
            ReturnMovement(1);
        }
        if (other.gameObject.name == "Player 3")
        {
            OnHit(2);
            ReturnMovement(2);
        }
        if (other.gameObject.name == "Player 4")
        {
            OnHit(3);
            ReturnMovement(3);
        }
    }
    private void OnHit(int Player)
    {
        playerController[Player].moveSpeed = 0;
        playerController[Player].RotationSpeed = 0;
        StartCoroutine(ReturnMovement(Player));
        starParticles[Player].Play();
    }
    IEnumerator ReturnMovement(int player)
    {
        yield return new WaitForSeconds(1f);
        playerController[player].moveSpeed = 10;
        playerController[player].RotationSpeed = 10;
        starParticles[player].Stop();
    }
}
