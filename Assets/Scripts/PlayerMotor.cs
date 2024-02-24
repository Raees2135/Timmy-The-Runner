using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour
{
    CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    public AudioSource gameOver;
    public AudioSource bgMusic;
    public Animator animator;
    public GameObject scoreContainer;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        bgMusic.Play();
        controller = GetComponent<CharacterController>();
        animator.SetInteger("fall", 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
        {
            return;
        }
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                moveVector.x = speed;
            }
            else
            {
                moveVector.x = -speed;
            }
        }


        moveVector.y = verticalVelocity * Time.deltaTime;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

        if (moveVector.y < -0.5)
        {
            Death();
        }
    }

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            Debug.Log("Hit");
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        gameOver.Play();
        bgMusic.Pause();
        GetComponent<Score>().OnDeath();
        animator.SetInteger("fall", 1);
        scoreContainer.SetActive(false);
    }
}
