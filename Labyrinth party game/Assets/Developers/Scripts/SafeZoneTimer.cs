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
        time += 1 * Time.deltaTime;
	}
    private void OnTriggerStay(Collider other)
    {
        if(time >= maxtime)
        {
            if(other.name != "Player 1")
            {
                GameObject.Find("Player 1").GetComponent<PickUpScore>().ResetScore(0);
            }
            if (other.name != "Player 2")
            {
                GameObject.Find("Player 2").GetComponent<PickUpScore>().ResetScore(1);
            }
            if (other.name != "Player 3")
            {
                GameObject.Find("Player 3").GetComponent<PickUpScore>().ResetScore(2);
            }
            if (other.name != "Player 4")
            {
                GameObject.Find("Player 4").GetComponent<PickUpScore>().ResetScore(3);
            }
        }
    }
}
