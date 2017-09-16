using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    // static: accessible to all objects
    public static float zVel = 10.0f;
    public static float zVelAdj = 1;
    public static int score = 0;

    public GameObject player;
    public GameObject obstaclePrefab;

	// Use this for initialization
	void Start () {
        score = 0;
        zVelAdj = 1;

        SpawnObstacle();
        SpawnObstacle();


        InvokeRepeating("SpawnObstacle", 0.0f, 0.6f);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void SpawnObstacle()
    {
        float playerZ = player.gameObject.transform.position.z;
        float zMin = playerZ + 40.0f;
        float zMax = playerZ + 50.0f;
        Vector3 position = new Vector3(Random.Range(-1, 2), 1.0f, Random.Range(zMin, zMax));
        Instantiate(obstaclePrefab, position, new Quaternion(0, 0, 0, 0));
    }
}
