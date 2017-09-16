using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, GM.zVel*1);
        offset = transform.position - player.transform.position;
	}
	
	// Run after all items in Update(), so after player motion
	void LateUpdate () {
        transform.position = player.transform.position + offset;
    }
}
