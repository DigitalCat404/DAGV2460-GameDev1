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
}