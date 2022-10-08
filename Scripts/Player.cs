using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    
    private SpriteRenderer sr;
    private Rigidbody2D myBody;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool isGrounded;

    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate() {
        PlayerJump();
    }

    void PlayerMoveKeyboard() 
    {
        movementX = Input.GetAxisRaw("Horizontal");
        
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if (movementX < 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }   

    void PlayerJump() {
        if (Input.GetButtonDown("Jump") && isGrounded && movementX > 0) {
            isGrounded = false;

            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            sr.flipX = false;  

            anim.SetBool(JUMP_ANIMATION, true);
            anim.SetBool(WALK_ANIMATION, false);         

        } else if (Input.GetButtonDown("Jump") && isGrounded && movementX < 0) {
            isGrounded = false;

            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            sr.flipX = true;

            anim.SetBool(JUMP_ANIMATION, true);
            anim.SetBool(WALK_ANIMATION, false);

        } else if (Input.GetButtonDown("Jump") && isGrounded && movementX == 0) {
            isGrounded = false;

            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
            anim.SetBool(JUMP_ANIMATION, true);
            anim.SetBool(WALK_ANIMATION, false);

        }

    } 

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }
}
