﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {
    public float health = 2.0f;
    public float score = 0.0f;
    public bool gameOver = false;

    //refrences to our UI element 
    public UnityEngine.UI.Text scoreUI;
    public UnityEngine.UI.Text healthUI;
    public GameObject gameOverUI;
    public GameObject youWinUI;

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.name == "Coin"){
            AddScore();
            Destroy(c.gameObject);
        }
        else if (c.tag == "Water")
        {
            health = 0.0f;
            healthUI.text = health.ToString();
            gameOverUI.SetActive(true);
            StopGame();
        }
        else if (c.tag == "Ending")
        {
            youWinUI.SetActive(true);
            StopGame();
        }
    }

    public void SubtractHealth()
    {
        health -= 1;
        healthUI.text = health.ToString();
        if (health == 0)
        {
            gameOverUI.SetActive(true);
            StopGame();
        }
    }

    public void AddScore()
    {
        score += 10;
        scoreUI.text = score.ToString();
    }

    public void StopGame()
    {
        gameOver = true;
        gameObject.SetActive(false);
    }
    
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
