using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    int currentHealth;
    int Maxhealth = 5;
    bool godmode = false; float godtimer = 2; float godleft;
    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKey(KeyCode.RightArrow) && body.velocity.x < maxSpeed)
        {
            body.AddForce(new Vector2(maxSpeed, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && body.velocity.x > -maxSpeed)
        {

            body.AddForce(new Vector2(-maxSpeed, 0));
        }
        else
        {
            body.AddForce(new Vector2(-body.velocity.x / 2, 0));
        }


        if (Input.GetKey(KeyCode.UpArrow) && isGrounded())
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
