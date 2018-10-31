using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScore : MonoBehaviour {


    [SerializeField]
    private Text[] m_PlayerScoreText;

    private int[] _PlayerScore = new int[4];

    private void Start()
    {
        m_PlayerScoreText[0].text = "Player 1: ";
        m_PlayerScoreText[1].text = "Player 2: ";
        m_PlayerScoreText[2].text = "Player 3: ";
        m_PlayerScoreText[3].text = "Player 4: ";
    }
    private void Update()
    {
        //print(_PlayerScore[0]);
        //print(_PlayerScore[1]);
        //print(_PlayerScore[2]);
        //print(_PlayerScore[3]);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == "Player 1")
        {
            if (other.gameObject.tag == "Point")
            {
                _PlayerScore[0] += 1;
                m_PlayerScoreText[0].text = "Player 1: " + _PlayerScore[0];
                other.gameObject.SetActive(false);
            }
        }
        if (gameObject.name == "Player 2")
        {
            if (other.gameObject.tag == "Point")
            {
                _PlayerScore[1] += 1;
                m_PlayerScoreText[1].text = "Player 2: " + _PlayerScore[1];
                other.gameObject.SetActive(false);
            }
        }
        if (gameObject.name == "Player 3")
        {
            if (other.gameObject.tag == "Point")
            {
                _PlayerScore[2] += 1;
                m_PlayerScoreText[2].text = "Player 3: " + _PlayerScore[2];
                other.gameObject.SetActive(false);
            }
        }
        if (gameObject.name == "Player 4")
        {
            if (other.gameObject.tag == "Point")
            {
                _PlayerScore[3] += 1;
                m_PlayerScoreText[3].text = "Player 4: " + _PlayerScore[3];
                other.gameObject.SetActive(false);
            }
        }
    }

    public void AddScore(int m_Player)
    {
        _PlayerScore[m_Player] += 1;
    }
}
