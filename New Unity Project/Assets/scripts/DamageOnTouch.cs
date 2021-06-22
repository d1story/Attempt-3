using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerMovement1 A = other.GetComponent<PlayerMovement1>();
        if(A != null)
        {
            A.change(amount);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}