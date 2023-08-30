using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    public Transform groundDetection;
    public float rayDistance = 0.2f;
    public LayerMask whatIsGround;

    //if falling
    private float lastY;
    public float fallTime;
    private float fallLeniency = 0.1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastY = transform.position.y;
        fallTime = Time.time;
    }


    void Update()
    {
        //shoot a ray downwards to spot ground
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance); //check for ground

        //if you can move forward on ground, do so
        if(groundInfo.collider){
            fallTime = Time.time;
            
            transform.Translate(Vector2.right * Time.deltaTime * speed);

        //else, flip around
        } else if((lastY <= transform.position.y)&&(Time.time - fallTime < fallLeniency)) {
            FlipEnemy();
        }

        lastY = transform.position.y;
    }
    

    void FlipEnemy(){

        //flip to face left
        if(isFacingRight){
            transform.eulerAngles = new Vector3(0,-180,0);

        //flip to face right
        } else {
            transform.eulerAngles = new Vector3(0,0,0);
        }

        isFacingRight = !isFacingRight;
    }
}
