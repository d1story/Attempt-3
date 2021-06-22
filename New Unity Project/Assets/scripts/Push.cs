using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float pushTimer;
    [SerializeField] private float pushTime;//how long you need to wait before you can push
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private bool player;//select which player it is to specify controls


    void Start()
    {
        body = GetComponent<Rigidbody2D>();//select the rigid body
        boxCollider = GetComponent<BoxCollider2D>();//and the box collider
        pushTimer = pushTime;

    }

    // Update is called once per frame
    void Update()
    {

        if (player)
        {//True will use "F" to push

            if (Input.GetKey(KeyCode.F) && pushTimer <= 0)
            {
                PushPlayer();
                pushTimer = pushTime;
            }

            if (pushTimer > 0)
            {
                pushTimer -= Time.deltaTime;
            }
        }
        else
        {//False will use "." to push.
            if (Input.GetKey(KeyCode.Period) && pushTimer <= 0)
            {
                PushPlayer();
                pushTimer = pushTime;
            }

            if (pushTimer > 0)
            {
                pushTimer -= Time.deltaTime;
            }
        }

    }

    private void PushPlayer()
    {
        RaycastHit2D raycastHit;
        //ray cast in front of player to check if it hits the other player (also check for direction)
        if (transform.localScale.y > 0)
        {
            print("push left");
            raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(-1, 0), 0.2f, playerLayer);
        }
        else
        {
            print("push right");
            raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(1, 0), 0.2f, playerLayer);
        }

        if (raycastHit.collider != null)
            raycastHit.rigidbody.AddForce(new Vector2(-(transform.localScale.y * 10000), 500));

    }
}
