using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPlayer : MonoBehaviour {

    [SerializeField]
    private PlayerController _Player;
    //[SerializeField]
    //private GameObject SlowDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SlowDown.SetActive(true);
            //gameObject.SetActive(false);
            _Player.moveSpeed += 5;
        }
    }
}

