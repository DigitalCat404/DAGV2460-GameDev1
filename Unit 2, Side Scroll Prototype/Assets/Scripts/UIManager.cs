using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int pickupCount = 0;
    public TextMeshProUGUI pickupCounterText; //the text UI element to change
    public TextMeshProUGUI gameOverText;

    void Start(){
        UpdatePickupCounter();
        //UpdateScoreText();
    }

    public void IncrementPickup(){
        pickupCount++;
        UpdatePickupCounter();
    }

    private void UpdatePickupCounter(){
        pickupCounterText.text = "Pickups: " + pickupCount;
    }

    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
    }

    /*public void IncreaseScore(int amount){
        score += amount;
        UpdateScoreText(); //update UI
    }

    public void DecreaseScore(int amount){
        score -= amount;
        UpdateScoreText(); //update UI
    }

    public void UpdateScoreText(){
        scoreText.text = "Score: " + score;
    }*/
}