using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private int currentHealth;
    [SerializeField] private int Maxhealth;
    bool godmode = false; float godtimer = 2; float godleft;
    // Start is called before the first frame update
    void Start()
    {
        //for movement
        body = GetComponent<Rigidbody2D>();//select the rigid body
        boxCollider = GetComponent<BoxCollider2D>();
        //for health
        currentHealth = Maxhealth;
    }
    //change health
    public void change(int amount)
    {
        if (!godmode)
        {
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, Maxhealth);
            Debug.Log(currentHealth + "/" + Maxhealth);
            godmode = true; godleft = godtimer;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //for health
        if (godmode) godleft -= Time.deltaTime;
        if (godleft < 0) godmode = false;
        //for movement
        if (Input.GetKey(KeyCode.D) && body.velocity.x < maxSpeed)
        {
            body.AddForce(new Vector2(maxSpeed, 0));
            transform.localScale = new Vector2(0.09f, -0.09f);

        }
        else if (Input.GetKey(KeyCode.A) && body.velocity.x > -maxSpeed)
        {

            body.AddForce(new Vector2(-maxSpeed, 0));
            transform.localScale = new Vector2(0.09f, 0.09f);
        }
        else
        {
            body.AddForce(new Vector2(-body.velocity.x / 2, 0));
        }


        if (Input.GetKey(KeyCode.W) && isGrounded())
        {//input.getkey checks if the key is being pressed.
            Jump();
        }

    }

    void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

}
