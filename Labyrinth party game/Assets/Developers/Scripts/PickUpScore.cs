using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScore : MonoBehaviour {

    private float[] _PlayerScore;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player 1")
        {

        }
        if (other.gameObject.name == "Player 2")
        {

        }
        if (other.gameObject.name == "Player 3")
        {

        }
        if (other.gameObject.name == "Player 4")
        {

        }
    }
}
