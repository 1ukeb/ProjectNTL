using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    public float speed;

    private float xInput;
    
    // Start is called before the first frame update
    void Start()
    {
       
        rigidbody.velocity = new Vector2(3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        SetVelocityX(xInput * speed);

    }
    //

    private void SetVelocityX(float velocity) 
    {
        rigidbody.velocity = new Vector2(velocity, 0);
    }
}

