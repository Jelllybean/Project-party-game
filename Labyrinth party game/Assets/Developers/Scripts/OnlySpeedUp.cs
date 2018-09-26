using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlySpeedUp : MonoBehaviour {

    [SerializeField]
    private PlayerController _Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _Player.moveSpeed += 5;
        }
    }
}

