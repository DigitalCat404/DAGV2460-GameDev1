using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    public Transform attackPos;
    public float meleeRange;
    public LayerMask whatIsEnemies;

    public int meleeDamage;
    public int fireDamage;

    public float cooldown = 0.3f; //attack cooldown
    private float lastAttack; //attack Delay

    private bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if((!isDead)&&(Time.time > lastAttack + cooldown)){ //prevent inputs at bad times

            //swing melee
            /*if(Input.GetButton("Fire2")){
                //gather list of all enemies hit in melee range
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, meleeRange, whatIsEnemies);

                //apply damage to all enemies hit
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(meleeDamage);
                }

                lastAttack = Time.time;
            
            //cast Fireball
            } else*/ if(Input.GetButton("Fire1")){
                lastAttack = Time.time;
                Fireball();
            }
        }
    }

    void Fireball(){
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }


    //render gizmo on screen in a red wire sphere
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, meleeRange);
    }

    public int GiveFireDamage(){
        return fireDamage;
    }

    public void setDeath(bool death){
        isDead = death;
    }
}