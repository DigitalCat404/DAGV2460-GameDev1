using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    //private int pickupCount = 0;
    //public TextMeshProUGUI pickupCounterText; //the text UI element to change
    
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI powerupText;

    void Start(){
        //UpdatePickupCounter();
        //UpdateScoreText();
    }


    public void Powerdown(){
        powerupText.gameObject.SetActive(false);
    }


    public void Powerup(string powerText){
        //Debug.Log("changing powerup text to: "+powerupText);
        powerupText.gameObject.SetActive(true);
        powerupText.text = powerText;
    }


    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
    }


//Vestige code, may be handy
    /*public void IncrementPickup(){
        pickupCount++;
        UpdatePickupCounter();
    }

    private void UpdatePickupCounter(){
        pickupCounterText.text = "Pickups: " + pickupCount;
    }*/

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