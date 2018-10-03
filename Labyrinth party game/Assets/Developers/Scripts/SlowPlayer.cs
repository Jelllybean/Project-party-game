using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour {

    [SerializeField]
    private PlayerController1 _Player;
    [SerializeField]
    private GameObject SpeedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpeedUp.SetActive(false);
            _Player.moveSpeed = 5;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _Player.moveSpeed = 10;
        Invoke("EnableSpeed", 0.5f);
    }

    private void EnableSpeed()
    {
        SpeedUp.SetActive(true);
    }
}
