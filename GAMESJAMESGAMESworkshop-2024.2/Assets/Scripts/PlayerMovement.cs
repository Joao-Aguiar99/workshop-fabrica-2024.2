using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float inputX;
    public bool inputJump;

    public float speed;
    public float forceJump;

    public bool isOnGround = false;
    public Animator anim;

    SpriteRenderer spriteRenderer;
    public bool flipX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        JumpLogic();
        Animations();

    }

    private void FixedUpdate(){

       MoveLogic(); 
    }

    public void Inputs(){
        
        inputX = Input.GetAxisRaw("Horizontal");
        inputJump = Input.GetKeyDown(KeyCode.Space);

    }

    public void JumpLogic(){

        if(inputJump == true && isOnGround == true){
            rb.velocity = new Vector2(rb.velocity.x, forceJump);
        }

    }

    public void MoveLogic(){

        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

    }
    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")){
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")){
            isOnGround = false;
        }
    }

    public void Animations(){

        anim.SetFloat("Horizontal", rb.velocity.x);

        if (inputX > 0){
            spriteRenderer.flipX = false;
        }else if(inputX < 0){
            spriteRenderer.flipX = true;
        }
    }
}   
