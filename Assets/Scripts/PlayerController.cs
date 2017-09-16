using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0.0f;
    public int laneNum = 1;   // left is 0, mid is 1, right is 2

    public bool controlLocked = false;

    public Text scoreText;

    public GameObject gameOverCanvas;

    private float slideSpeed = 4.0f;

	// Use this for initialization
	void Start () {
        //GM.score = 0;
        scoreText.text = "Score: " + GM.score.ToString();
        gameOverCanvas.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, GM.zVel);

        if ((Input.GetAxisRaw("Horizontal") == -1 && laneNum > 0) && (!controlLocked))
        {
            controlLocked = true;
            horizVel = (-1)*slideSpeed;
            StartCoroutine(stopSlide());
            laneNum--;
        }
        if ((Input.GetAxisRaw("Horizontal") == 1 && laneNum < 2) && (!controlLocked))
        {
            controlLocked = true;
            horizVel = slideSpeed;
            StartCoroutine(stopSlide());
            laneNum++;
        }

        GM.score++;
        scoreText.text = "Score: " + GM.score.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("lethal"))
        {
            Destroy(gameObject);
            GM.zVelAdj = 0;
            gameOverCanvas.gameObject.SetActive(true);
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(1 / slideSpeed);
        horizVel = 0;
        controlLocked = false;
    }
}
