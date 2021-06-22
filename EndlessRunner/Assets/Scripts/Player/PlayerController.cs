using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    public float laneDistance = 4;
    private int desirePos = 1;
    public float jumpForce;
    public float gravity = -12f;
    public Animator animator;
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isSliding = false;
    enum Position
    {
        left,
        middle,
        right
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        int index = PlayerPrefs.GetInt("currentIndex", 0);
        animator = this.GetComponent<ShopManager>().characters[index].GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted) {
            return;
        }
        if(forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        animator.SetBool("isGameStarted", true);
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        direction.z = forwardSpeed;
        if (isGrounded)
        {
            direction.y = 0;
            if (SwipeManager.swipeUp) {
                jump();
            }
                 
        }
        else {
            direction.y += gravity * Time.deltaTime;

        }
        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }
        
        if (SwipeManager.swipeRight) {
            desirePos++;
            if (desirePos == 3) {
                desirePos = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desirePos--;
            if (desirePos == -1) {
                desirePos = 0;
            }
        }

        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desirePos == 0) {
            targetPos += Vector3.left * laneDistance;
        }
        if (desirePos == 2)
        {
            targetPos += Vector3.right * laneDistance;
        }

        if (transform.position != targetPos) {
            Vector3 diff = targetPos - transform.position;
            Vector3 modeDir = diff.normalized * 25 * Time.deltaTime;
            if (modeDir.sqrMagnitude < diff.sqrMagnitude)
            {
                controller.Move(modeDir);
            }
            else
            {
                controller.Move(diff);
            }
        }
        
       
        controller.Move(direction * Time.deltaTime);

    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        yield return new WaitForSeconds(1.3f);
        isSliding = false;
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);

    }

    private void jump()
    {
        direction.y = jumpForce;
    }

  

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag.Equals("Obstacle")) {

            PlayerManager.isGameOver = true;
            FindObjectOfType<AudioManager>().playSound("GameOver");
        }
    }
}
