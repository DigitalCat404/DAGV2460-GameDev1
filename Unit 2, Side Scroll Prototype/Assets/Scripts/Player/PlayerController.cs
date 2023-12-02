using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Stats
    [Header("PlayerStats")]
    private float horizontalInput;
    public float speed = 10;
    public float jumpForce; //how high player jumps
    public string inventory = "";
    public bool isDead = false; //removes control of player if dead
    
    
    //Player Rigidbody
    [Header("Rigidbody Components")]
    private Rigidbody2D rb;
    private bool isFacingRight = true;


    //Player Jump
    [Header("Jump Settings")]
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool dubJump;

    //Animations
    [Header("Animations")]
    private Animator playerAnim;

    //Game Objects
    [Header("Game Objects")]
    private UIManager UIManager;
    public Transform firePoint;


    void Start(){
        //identify the rigidbody component on Player
        rb = GetComponent<Rigidbody2D>();
        //identify animations on player
        playerAnim = GetComponent<Animator>();

        UIManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    //called between a fixed number of frames, best for physics based movement
    void FixedUpdate(){
        //check for ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //check for ground

        if(!isDead){
            //set horizontal to receive values from keyboard
            horizontalInput = Input.GetAxis("Horizontal");
            
            //moves player left and right   Vector3.right = X-axis
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
            //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            //if moving, walk animation
            CheckWalk();

            //flip player when changing left/right direction
            if((!isFacingRight && horizontalInput > 0)||(isFacingRight && horizontalInput < 0)){
                FlipPlayer();
            }
        }
    }

    // Update is called once per frame, per cycle
    void Update(){
        //reset double jump and jump animation when grounded
        if(isGrounded){
            dubJump = true;
            playerAnim.SetBool("isGrounded", true);
        } else {
            playerAnim.SetBool("isGrounded", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && ((dubJump || isGrounded)&&(!isDead)) ){
            rb.velocity = Vector2.up * jumpForce; //make player jump

            //set jump animation trigger
            playerAnim.SetTrigger("Jump_Trig");

            //if double jumping, remove double jump
            if(!isGrounded){
                dubJump = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other){

        if(!isDead){
            //if hit by pickup, collect and put in inventory
            if(other.tag == "Pickup"){
                inventory = other.tag;
                Debug.Log("Inventory: " + inventory);
                UIManager.IncrementPickup();

                //delete object with trigger striking player
                Destroy(other.gameObject);
                //Debug.Log("deleted collision");
            }
        }
    }


    void FlipPlayer(){
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; //local variable
        scaler.x *= -1; //declare flipping the sprite graphic
        transform.localScale = scaler; //perform the flip

        if(isFacingRight){
            firePoint.transform.eulerAngles = new Vector3(0,0,0);
        } else {
            firePoint.transform.eulerAngles = new Vector3(0,-180,0);
        }
    }


    void CheckWalk(){
        if(horizontalInput != 0){
                    //what bool, value to set it to
            playerAnim.SetBool("isWalking", true);
        } else {
            playerAnim.SetBool("isWalking", false);
        }
    }


    public void setInventory(string item){
        inventory = item;
        Debug.Log("Inventory: " + inventory);
    }


    public void setDeath(bool death){
        isDead = death;

        if(isDead){
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
