using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWinScript : MonoBehaviour {

    [SerializeField]
    private GameObject WinTekst;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Win")
        {
            WinTekst.SetActive(true);
        }
    }
}
