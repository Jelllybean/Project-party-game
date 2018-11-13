using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneTimer : MonoBehaviour {
    float time;
    public float maxtime;
	void Start () {
		//zet dit script op een collider voor de safezone
        // de collider moet staan op "Trigger"
	}
	void Update () {
        time += Time.deltaTime;
	}
    private void OnTriggerStay(Collider other)
    {
        if(time >= maxtime)
        {
            if(other.name != "Char Player 1")
            {
                GameObject.Find("Char Player 1").GetComponent<PickUpScore>().ResetScore(1);
            }
            if (other.name != "Char Player 2")
            {
                GameObject.Find("Char Player 2").GetComponent<PickUpScore>().ResetScore(2);
            }
            if (other.name != "Char Player 3")
            {
                GameObject.Find("Char Player 3").GetComponent<PickUpScore>().ResetScore(3);
            }
            if (other.name != "Char Player 4")
            {
                GameObject.Find("Char Player 4").GetComponent<PickUpScore>().ResetScore(4);
            }
        }
    }
}
