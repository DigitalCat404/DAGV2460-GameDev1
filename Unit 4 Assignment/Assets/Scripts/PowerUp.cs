using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public string powerType = "NULL";

    private PowerupState pState;
    public GameObject PowerupSound;
    

    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Player")){
            pState = other.GetComponent<PowerupState>();

            pState.PowerChange(powerType);
            //Debug.Log("obtained " + powerType);

            Instantiate(PowerupSound,transform.position,transform.rotation);

            Invoke("Reactivate", 5f);
            gameObject.SetActive(false);            
        }
    }

    //respawn after a time
    private void Reactivate(){
        gameObject.SetActive(true);
    }
}