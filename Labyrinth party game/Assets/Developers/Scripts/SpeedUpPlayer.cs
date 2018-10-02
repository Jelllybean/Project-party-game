using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPlayer : MonoBehaviour {

    [SerializeField]
    private PlayerController1 _Player;
    [SerializeField]
    private GameObject SlowDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SlowDown.SetActive(false);
            _Player.moveSpeed = 15;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _Player.moveSpeed = 10;
            Invoke("EnableSlow", 1f);
        }
    }
    public void EnableSlow()
    {
        SlowDown.SetActive(true);
    }
}

