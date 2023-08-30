using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlierAI : MonoBehaviour
{
    public float speed = 2;
    public float leftEdge = -3;
    public float rightEdge = 3;
    private float leftBound;
    private float rightBound;
    private Rigidbody2D rb;
    private bool isFacingRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        leftBound = transform.position.x + leftEdge;
        //Debug.Log("Left bound: " + leftBound);
        
        rightBound = transform.position.x + rightEdge;
        //Debug.Log("Right bound: " + rightBound);
    }


    void FixedUpdate()
    {
        //if not at edge of pacing zone, move
        if(((transform.position.x > leftBound)&&(!isFacingRight))||(transform.position.x < rightBound)&&(isFacingRight)){
            
            if(isFacingRight){
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            } else {
                transform.Translate(Vector3.right * Time.deltaTime * -speed);
            }

        //else, flip around
        } else {
            FlipEnemy();
        }

    }
    

    void FlipEnemy(){
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; //local variable
        scaler.x *= -1; //declare flipping the sprite graphic
        transform.localScale = scaler; //perform the flip
    }
}
