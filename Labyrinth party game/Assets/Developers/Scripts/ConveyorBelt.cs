using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    [SerializeField]
    private GameObject Player;

    [SerializeField] private bool isRight;
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isUp;
    [SerializeField] private bool isDown;

    Vector3 _Forward;

    private Vector3 _PlayerPos;
    void Start ()
    {
        _Forward = transform.forward;
        _Forward.y = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
         _PlayerPos = Player.transform.position;	
	}
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(isUp == true)
            {
                Player.transform.Translate(Vector3.forward * 7.5f * Time.deltaTime, Space.World);
            }
            if (isDown == true)
            {
                Player.transform.Translate(Vector3.forward * -7.5f * Time.deltaTime, Space.World);
            }
            if (isRight == true)
            {
                Player.transform.Translate(Vector3.right * 7.5f * Time.deltaTime, Space.World);
            }
            if (isLeft == true)
            {
                Player.transform.Translate(Vector3.right * -7.5f * Time.deltaTime, Space.World);
            }
        }
    }
}
