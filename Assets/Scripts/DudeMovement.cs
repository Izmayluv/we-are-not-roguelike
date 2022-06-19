using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D Dude;
    public GameObject player;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator animator;
    private string currentAnimation;

    // Start is called before the first frame update
    void Start()
    {
        Dude = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;


        if (Input.GetKey("w") && Input.GetKey("a") && !Input.GetKey("s") &&  !Input.GetKey("d"))
        {
            ChangeAnimation("LeftUp");
        }

        if (Input.GetKey("w") && Input.GetKey("d") && !Input.GetKey("s") &&  !Input.GetKey("a"))
        {
            ChangeAnimation("RightUp");
        }

        if (Input.GetKey("s") && Input.GetKey("a") && !Input.GetKey("w") &&  !Input.GetKey("d"))
        {
            ChangeAnimation("LeftDown");
        }
                
        if (Input.GetKey("s") && Input.GetKey("d") && !Input.GetKey("w") &&  !Input.GetKey("a"))
        {
            ChangeAnimation("RightDown");
        }

        if (Input.GetKey("w") && !Input.GetKey("d") && !Input.GetKey("a") &&  !Input.GetKey("s"))
        {
            ChangeAnimation("Up");
        }

        if (Input.GetKey("a") && !Input.GetKey("w") && !Input.GetKey("s") &&  !Input.GetKey("d"))
        {
            ChangeAnimation("Left");
        }

        if (Input.GetKey("s") && !Input.GetKey("d") && !Input.GetKey("a") &&  !Input.GetKey("w"))
        {
            ChangeAnimation("Down");
        }

        if (Input.GetKey("d") && !Input.GetKey("w") && !Input.GetKey("s") &&  !Input.GetKey("a"))
        {
            ChangeAnimation("Right");
        }
            //////stand
        if (Input.GetKeyUp("w") && Input.GetKeyUp("a"))
        {
            ChangeAnimation("StandLeftUp");
        }

        if (Input.GetKeyUp("w") && Input.GetKeyUp("d"))
        {
            ChangeAnimation("StandRightUp");
        }

        if (Input.GetKeyUp("s") && Input.GetKeyUp("a"))
        {
            ChangeAnimation("StandLeftDown");
        }
                
        if (Input.GetKeyUp("s") && Input.GetKeyUp("d"))
        {
            ChangeAnimation("StandRightDown");
        }

        if (Input.GetKeyUp("w") && !Input.GetKeyUp("d") && !Input.GetKeyUp("a") &&  !Input.GetKeyUp("s"))
        {
            ChangeAnimation("StandUp");
        }

        if (Input.GetKeyUp("a") && !Input.GetKeyUp("w") && !Input.GetKeyUp("s") &&  !Input.GetKeyUp("d"))
        {
            ChangeAnimation("StandLeft");
        }

        if (Input.GetKeyUp("s") && !Input.GetKeyUp("d") && !Input.GetKeyUp("a") &&  !Input.GetKeyUp("w"))
        {
            ChangeAnimation("StandDown");
        }

        if (Input.GetKeyUp("d") && !Input.GetKeyUp("w") && !Input.GetKeyUp("s") &&  !Input.GetKeyUp("a"))
        {
            ChangeAnimation("StandRight");
        }
    
    }

    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation) return;

        animator.Play(animation);
        currentAnimation = animation;
    }
    
    void FixedUpdate()
    {
        Dude.MovePosition(Dude.position + moveVelocity * Time.fixedDeltaTime);
    }
}
