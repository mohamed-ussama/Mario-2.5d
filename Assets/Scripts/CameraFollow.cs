using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    Transform playerTransform;
    Vector3 cameraPosition;
    [SerializeField]
    float smooth =2;
	void Start () {
        cameraPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        transform.position = cameraPosition;
	}
	
	// Update is called once per frame
	void Update () {
        cameraPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime*smooth);
	}
}
