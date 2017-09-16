using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    // static: accessible to all objects
    public static float zVel = 5.0f;
    public static float zVelAdj = 1;
    public static int score = 0;

    public GameObject player;
    public GameObject obstaclePrefab;

	// Use this for initialization
	void Start () {
        score = 0;
        zVelAdj = 1;

        InvokeRepeating("SpawnObstacle", 0.0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void SpawnObstacle()
    {
        float playerZ = player.gameObject.transform.position.z;
        Vector3 position = new Vector3(Random.Range(-1, 2), 0.5f, Random.Range(playerZ + 10.0f, playerZ + 200.0f));
        Instantiate(obstaclePrefab, position, obstaclePrefab.transform.rotation);
    }
}
