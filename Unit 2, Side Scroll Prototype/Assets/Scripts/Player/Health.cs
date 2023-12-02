using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //add UI library

public class Health : MonoBehaviour
{
    [Header("PlayerStats")]
    public int maxHealth;
    public int curHealth;
    public float invulDuration = 0.5f;
    private float lastHitTime = 0;

    [Header("Damage Receiving")]
    private Color original;
    private Color invulnerable;
    public AudioClip ouch;

    [Header("Heart System")]
    public int numOfHearts; //number of hearts
    public Image[] hearts; //Number of heart images in the UI
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Game Objects")]
    private Animator playerAnim;
    private PlayerController playerController;
    private PlayerAttack playerAttack;
    private UIManager UIManager;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        numOfHearts = curHealth;

        HeartUpdate();

        original = GetComponent<SpriteRenderer>().color;
        invulnerable = new Color(original.r, original.g, original.b, 0.5f);

        playerAnim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponent<PlayerAttack>();
        UIManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    void Update(){
        if(Time.time > lastHitTime + invulDuration){
            InvulTransparency(false);
        } else {
            InvulTransparency(true);
        }
    }
    
    
    public void TakeDamage(int damage){
        
        if(Time.time > lastHitTime + invulDuration){
            curHealth -= damage;
            Debug.Log("Player took " + damage);

            if(curHealth <= 0){
                GameOver();
            } else {
                lastHitTime = Time.time;

                //play audio for taking damage
                GetComponent<AudioSource>().PlayOneShot(ouch, 1f);
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


    private void InvulTransparency(bool isInvul){
        //make transparent while invul
        if(isInvul){
            GetComponent<SpriteRenderer>().color = invulnerable;

        //make opaque on exit invul
        } else {
            GetComponent<SpriteRenderer>().color = original;
        }
    }

    private void GameOver(){
        playerAnim.SetBool("isDead",true);

        playerController.setDeath(true);
        playerAttack.setDeath(true);

        UIManager.GameOver();

        Debug.Log("Game over!");

        Invoke("FreezeTime", 1f);
    }

    private void FreezeTime(){
        Time.timeScale = 0;
        Debug.Log("freezing time");
    }
}
