using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //public int scoreToGive;
    private UIManager uIManager;
    private PlayerController playerController;

    //audio
    //add hit audio

    public int healthValue = 1;

    void Start(){
        uIManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    /*private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("pickup found contact");

        if(other.gameObject.CompareTag("Player")){
            uIManager.IncrementPickup();
            playerController.setInventory(gameObject.tag);
            Destroy(gameObject);
            
        }
    }*/

    //if out of health, delete UFO
    /*void CheckDeath(){
        if(healthValue <= 0){
            Explosion();
            scoreManager.IncreaseScore(scoreToGive);
            Destroy(this.gameObject);
        }
    }*/
}