using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health playerHealth; //referencing something
    public int health = 1;
    public int damage = 1;

    void Start(){
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    public void TakeDamage(int damage){
        health -= damage;

        if(health <= 0){
            Debug.Log(gameObject.tag + " perished");
            Destroy(gameObject);
            //while destroying and instantiating is fine, you should recycle to reduce restrain
        } else {
            Debug.Log(gameObject.tag + " took " + damage);
        }
    }

    void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.CompareTag("Player")){
            playerHealth.TakeDamage(damage);
            Debug.Log(gameObject.name + " deals " + damage + " to player");
        }
    }
}