using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    private Health playerHealth;
    private SimplerAI myAI;
    public int damage = 1;


    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
        myAI = this.GetComponent<SimplerAI>();
    }


    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Player")){
            playerHealth.TakeDamage(damage);
            Debug.Log(gameObject.name + " deals " + damage + " to player");

            PauseAI();
        }
    }


    private void PauseAI(){
        myAI.Pause(3);
    }
}
