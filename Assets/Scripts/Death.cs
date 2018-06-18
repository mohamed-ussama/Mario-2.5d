using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"||other.tag == "Invincable")
        {

            other.GetComponent<Player>().TakeDamage(100);

        }
    }
}
