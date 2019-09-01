using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;

    Rigidbody rb;

    Animator animator;

    public float speed;

    [HideInInspector] public bool walkb;

    private void OnCollisionStay(Collision collision)
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------
        //MOVE FORWARD
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("walk",true);
            transform.position += transform.forward.normalized * speed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("walk", false);
        }
        //----------------------------------------------------

        //----------------------------------------------------
        //MOVE LEFT
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walkl", true);
            transform.position += -transform.right.normalized * speed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("walkl", false);
        }
        //----------------------------------------------------

        //----------------------------------------------------
        //MOVE RIGHT
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walkr", true);
            transform.position += transform.right.normalized * speed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("walkr", false);
        }
        //----------------------------------------------------

        //----------------------------------------------------
        //MOVE FORWARD & RIGHT
        if (animator.GetBool("walk") == true && animator.GetBool("walkr") == true)
        {
            animator.SetBool("walk", false);
            animator.SetBool("walkr", false);
            animator.SetBool("walksr", true);
            transform.position += ((transform.forward + transform.right).normalized / (speed * speed * speed)) * Time.deltaTime;
        }
        else
        {
            animator.SetBool("walksr", false);
        }
        //----------------------------------------------------

        //----------------------------------------------------
        //MOVE FORWARD & LEFT
        if (animator.GetBool("walk") == true && animator.GetBool("walkl") == true)
        {
            animator.SetBool("walk", false);
            animator.SetBool("walkl", false);
            animator.SetBool("walksl", true);
            transform.position += ((transform.forward + (-transform.right)).normalized / (speed* speed *speed)) * Time.deltaTime;
        }
        else
        {
            animator.SetBool("walksl", false);
        }
        //----------------------------------------------------

        //----------------------------------------------------
        //MOVE BACKWARD
        if (Input.GetKey(KeyCode.S))
        {
            walkb = true;
            animator.SetBool("walk", true);
            transform.position += -transform.forward.normalized * speed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("walk", false);
            walkb = false;
        }
        //----------------------------------------------------
    }
}
