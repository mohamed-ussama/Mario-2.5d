using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player" || collision.gameObject.tag == "Invincable")
        {
            collision.gameObject.GetComponent<Controller2D>().Jump();
            collision.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Destroy(this.gameObject);
        }
    }
}
