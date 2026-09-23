using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;

//using System.Numerics;


//using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected internal float xSpeed = 0.25f;
    [SerializeField] protected internal float ySpeed = 10f;
    //Variables for collision
    protected bool isGrounded = false;
    protected int health = 100;
    protected int iFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float vert = 0;
        if (Input.GetButtonDown("Jump")){//} && isGrounded){
            Debug.Log("pp");
            vert = ySpeed;
            rb.velocity += new Vector2(0, vert);
            //AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horz = Input.GetAxisRaw("Horizontal");
        int sprintMod = 1;
        if (Input.GetButtonDown("Sprint")) Debug.Log("bb");//sprintMod = 2;
        transform.position = new Vector2(transform.position.x + horz * xSpeed * sprintMod, transform.position.y);
    }
}
