using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.tag = "Invincable";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.white;
            Destroy(this.gameObject);
        }
    }
}
