using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour {

    [SerializeField]
    private PlayerController _Player;
    //[SerializeField]
    //private GameObject SpeedUp;
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SpeedUp.SetActive(true);
            //gameObject.SetActive(false);
            _Player.moveSpeed -= 5;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
