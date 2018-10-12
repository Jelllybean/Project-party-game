using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    [SerializeField]
    private GameObject[] Player;

    [SerializeField] private bool isRight;
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isUp;
    [SerializeField] private bool isDown;


    private int m_currentPlayer;
    Vector3 _Forward;

    private Vector3 _PlayerPos;
    void Start()
    {
        _Forward = transform.forward;
        _Forward.y = 0;
    }

    void Update()
    {
        _PlayerPos = Player[m_currentPlayer].transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player 1")
        {
            SelectPlayer(0);
        }
        if (other.name == "Player 2")
        {
            SelectPlayer(1);
        }
        if (other.name == "Player 3")
        {
            SelectPlayer(2);
        }
        if (other.name == "Player 4")
        {
            SelectPlayer(3);
        }
    }
    private void SelectPlayer(int _Player)
    {
        m_currentPlayer = _Player;
        MovePlayer();
    }
    private void MovePlayer()
    {
        if(isUp == true)
        {
            Player[m_currentPlayer].transform.Translate(Vector3.forward * 7.5f * Time.deltaTime, Space.World);
        }
        if(isDown == true)
        {
            Player[m_currentPlayer].transform.Translate(Vector3.forward * -7.5f * Time.deltaTime, Space.World);
        }
        if(isRight == true)
        {
            Player[m_currentPlayer].transform.Translate(Vector3.right * 7.5f * Time.deltaTime, Space.World);
        }
        if(isLeft == true)
        {
            Player[m_currentPlayer].transform.Translate(Vector3.right * -7.5f * Time.deltaTime, Space.World);
        }
    }
}
