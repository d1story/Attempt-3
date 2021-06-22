using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject2 : MonoBehaviour
{
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerMovement2 A = other.GetComponent<PlayerMovement2>();
        if (A != null)
        {
            A.change(amount);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
