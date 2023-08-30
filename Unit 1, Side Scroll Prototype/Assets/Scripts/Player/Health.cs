using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //add UI library

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public float invulDuration = 0.5f;
    private float invulTimer = 0;

    public int numOfHearts; //number of hearts
    public Image[] hearts; //Number of heart images in the UI
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        curHealth = maxHealth;
        numOfHearts = curHealth;

        HeartUpdate();
    }
    
    
    public void TakeDamage(int damage){
        
        if(Time.time > invulTimer + invulDuration){
            curHealth -= damage;
            Debug.Log("Player took " + damage);

            if(curHealth <= 0){
                Time.timeScale = 0;
                Debug.Log("Game over!");
            } else {
                invulTimer = Time.time;
            }

            HeartUpdate();

        } else {
            Debug.Log("Protected!");
        }
    }

    
    public void AddHealth(int heal){
        curHealth += heal;

        if(curHealth >= maxHealth){
            curHealth = maxHealth;
        }

        HeartUpdate();

        Debug.Log("Player healed " + heal);
    }


    private void HeartUpdate(){
        //prevent overflow
        if(curHealth > numOfHearts){
            curHealth = numOfHearts;
        }

        //populate and update hearts on HUD
        for(int i = 0; i < hearts.Length; i++){
            if(i < curHealth){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
