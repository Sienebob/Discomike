using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D myRB;
    SpriteRenderer MyRenderer;

    public bool canMove = true;
    bool facingRight = true;

    public float maxSpeed;
    public BoxCollider2D BoxCollider;


    //Hyppyjutut
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;
    float groundCheckRadius = 0.1f;
    public bool isGrounded;
    public bool isGroundedOnLastFrame = false;
    public bool isFalling = false;

    //ampuminen
    public GameObject bullet;
    private float timeBtwAttack;
    public float startTimeBtwShoot;
    public float VinylShootSpeed;


    public int myCoins;
    




    //Animaatiojutut
    public Animator animator;
    public float vertical;
    public GameObject reward;

    
    void Start()
    {
        
        myRB = GetComponent<Rigidbody2D>();
        MyRenderer = GetComponent<SpriteRenderer>();

      
    }

 
    void Update()
    {
        Movement();
        Jump();

        if (myCoins > 0)
        { 
       Shoot();
             }

        goDown();
   

        animator.SetFloat("Vertical", myRB.velocity.y);

        myCoins = GetComponent<PlayerInventory>().Coins;

    }
    

    private void Jump()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);

        }
        if (!isGrounded)
        {
            animator.SetBool("isGrounded", false);
            isGroundedOnLastFrame = false;

        }
        if (isGrounded && !isGroundedOnLastFrame)
        {

            Land();
            isGroundedOnLastFrame = isGrounded;

        }




        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
         
            SoundManagerScript.PlaySound("Jump");
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        
            

        }

    }

    private void Movement()
    {

        {
            float move = Input.GetAxis("Horizontal");

            if (canMove)
            {
                if (move > 0 && !facingRight)
                    Flip();
                else if (move < 0 && facingRight)
                    Flip();
                myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

                //Kun liikkuu asettaa Speed arvon animaattorissa muuksi kun 0 ja soittaa liikkumisanimaation
                animator.SetFloat("Speed", Mathf.Abs(move));
            }
            else
            {
                myRB.velocity = new Vector2(0, myRB.velocity.y);
            }
            void Flip()
            {
                facingRight = !facingRight;
                MyRenderer.flipX = !MyRenderer.flipX;
            }
       
     
            
        
        }
    }
  

        private void Land()
        {
            SoundManagerScript.PlaySound("Land");
            Debug.Log("soundland");
        }



        private void goDown()

        {
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                if (transform.position.y > -5.0)
                {

                    Debug.Log("painettu alas");
                    GetComponent<BoxCollider2D>().isTrigger = true;
                    Invoke("Falling", 0.2f);

                }


            }
        
    
    
    
    
    }

        public void Falling()
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }

    public void Shoot()
    {


        Vector3 bulletR = new Vector3(-0, 0, 0);
        Vector3 bulletL = new Vector3(0, 0, 0);
        Vector3 bulletU = new Vector3(0, 0, 0);


        //Koilliseen
        if ((Input.GetKey(KeyCode.Z)|| Input.GetKey(KeyCode.Mouse0)) && timeBtwAttack <= 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))

        {
            SoundManagerScript.PlaySound("Shoot");
            timeBtwAttack = startTimeBtwShoot;
            GameObject bulletInstance = Instantiate(bullet, transform.position + bulletR, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(VinylShootSpeed / 2, VinylShootSpeed / 2), ForceMode2D.Impulse);


        }

        //Ylös
        if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Mouse0)) && timeBtwAttack <= 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))

        {
            SoundManagerScript.PlaySound("Shoot");
            timeBtwAttack = startTimeBtwShoot;
            GameObject bulletInstance = Instantiate(bullet, transform.position + bulletL, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, VinylShootSpeed), ForceMode2D.Impulse);


        }


        //Oikealle
        if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Mouse0)) && timeBtwAttack <= 0 && facingRight)

        {
            SoundManagerScript.PlaySound("Shoot");
            timeBtwAttack = startTimeBtwShoot;
            GameObject bulletInstance = Instantiate(bullet, transform.position + bulletR, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(VinylShootSpeed, 0), ForceMode2D.Impulse);


        }

        //Luoteeseen

        if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Mouse0)) && timeBtwAttack <= 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            SoundManagerScript.PlaySound("Shoot");
            timeBtwAttack = startTimeBtwShoot;
            GameObject bulletInstance = Instantiate(bullet, transform.position + bulletL, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * VinylShootSpeed, VinylShootSpeed), ForceMode2D.Impulse);


        }
        //Vasen
        if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Mouse0)) && timeBtwAttack <= 0 && !facingRight)
        {
            SoundManagerScript.PlaySound("Shoot");
            timeBtwAttack = startTimeBtwShoot;
            GameObject bulletInstance = Instantiate(bullet, transform.position + bulletL, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * VinylShootSpeed, 0), ForceMode2D.Impulse);

        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        myCoins --;
    }
}

    //Android hommia
    /*

        //ei toimi
        public void JumpMobile()
        {
        
        myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);

        }

    public void LeftMobile()
    {
        Debug.Log("NappiPainettu");
        myRB.velocity = new Vector2(10 * maxSpeed, myRB.velocity.y);
    }
    */
    

