using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    [SerializeField]
    private GameObject[] playerObj;

    [SerializeField] private bool isRight;
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isUp;
    [SerializeField] private bool isDown;
    [SerializeField] private float f_Force;

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
        _PlayerPos = playerObj[m_currentPlayer].transform.position;
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
            playerObj[m_currentPlayer].transform.Translate(Vector3.forward * f_Force * Time.deltaTime, Space.World);
        }
        if(isDown == true)
        {
            playerObj[m_currentPlayer].transform.Translate(Vector3.forward * -f_Force * Time.deltaTime, Space.World);
        }
        if(isRight == true)
        {
            playerObj[m_currentPlayer].transform.Translate(Vector3.right * f_Force * Time.deltaTime, Space.World);
        }
        if(isLeft == true)
        {
            playerObj[m_currentPlayer].transform.Translate(Vector3.right * -f_Force * Time.deltaTime, Space.World);
        }
    }
}
