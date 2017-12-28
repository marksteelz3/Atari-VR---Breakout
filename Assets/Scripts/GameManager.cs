using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int lives = 3;
    public int bricks = 30;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject breakOut;
    public GameObject bricksPrefab;
    //public GameObject paddle;
    public GameObject deathParticles;
    public static GameManager instance = null;

    //private GameObject clonePaddle;
	
	void Start () {
		if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        //Setup();
	}

    /*public void Setup()
    {
        //clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }*/

    void CheckGameOver()
    {
        if (bricks == 0)
        {
            youWon.SetActive(true);
            //Time.timeScale = 0.25f;
            //Invoke("Reset", resetDelay);
        }

        if (lives < 1 && bricks > 0)
        {
            breakOut.SetActive(false);
            gameOver.SetActive(true);
            bricks = -1;
            //Time.timeScale = 0.25f;
            //Invoke("Reset", resetDelay);
        }
    }

    /*private void Reset()
    {
        Time.timeScale = 1f;
        //Application.LoadLevel(Application.loadedLevel);
    }*/

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        //Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        //Destroy(clonePaddle);
        //Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    /*void SetupPaddle()
    {
        //clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }*/

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
