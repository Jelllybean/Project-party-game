using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeZoneTimer : MonoBehaviour
{
    public float time;
    public float maxtime;
    Collider colliders;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private GameObject[] ToTheMiddle;
    private bool Active;
    void Start()
    {
        //zet dit script op een collider voor de safezone
        // de collider moet staan op "Trigger"
        time = 100;
        Active = true;
    }
    void Update()
    {
        if (Active == true)
        {
            if (time <= 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    ToTheMiddle[i].SetActive(true);
                }
                Invoke("DisableText", 5f);
            }
        }

        timerText.text = "" + Mathf.RoundToInt(time);
        time -= Time.deltaTime;
        if (time <= maxtime)
        {
            if (colliders == null)
            {
                GameObject.Find("Player 1").GetComponent<PickUpScore>().ResetScore(0);
                GameObject.Find("Player 2").GetComponent<PickUpScore>().ResetScore(1);
                GameObject.Find("Player 3").GetComponent<PickUpScore>().ResetScore(2);
                GameObject.Find("Player 4").GetComponent<PickUpScore>().ResetScore(3);
            }
            else if (colliders.name != "Player 1")
            {
                GameObject.Find("Player 1").GetComponent<PickUpScore>().ResetScore(0);
                Debug.Log("player1scorereset");
            }
            else if (colliders.name != "Player 2")
            {
                GameObject.Find("Player 2").GetComponent<PickUpScore>().ResetScore(1);
            }
            else if (colliders.name != "Player 3")
            {
                GameObject.Find("Player 3").GetComponent<PickUpScore>().ResetScore(2);
            }
            else if (colliders.name != "Player 4")
            {
                GameObject.Find("Player 4").GetComponent<PickUpScore>().ResetScore(3);
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        colliders = other;
    }
    private void DisableText()
    {
        Active = false;
        for (int i = 0; i < 4; i++)
        {
            ToTheMiddle[i].SetActive(false);
        }
    }
}