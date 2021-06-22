using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{

    [SerializeField] private bool player;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (player)//Can this section be done in start?
        {
            PlayerMovement1 A = other.GetComponent<PlayerMovement1>();
            if (A != null)//this check has to be inside due to scope. (two variables could be used and declared outside, but whatever)
            {
                A.change(amount);
            }
        }
        else
        {
            PlayerMovement2 A = other.GetComponent<PlayerMovement2>();
            if (A != null)
            {
                A.change(amount);
            }
        }


    }
    // Update is called once per frame
    void Update()
    {

    }
}