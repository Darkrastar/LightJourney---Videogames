using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{


    private CharacterController charController;
    public bool isJumping;
    // Use this for initialization
    public float life;
    public Transform cam;
    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public int velas;

    public Image vela1;
    public Image vela2;
    public Image vela3;


    void Start()
    {

        charController = GetComponent<CharacterController>();


        life = 100.0f;
        velas = 0;
        vela1 = GameObject.Find("Vela1").GetComponent<Image>();
        vela2 = GameObject.Find("Vela2").GetComponent<Image>();
        vela3 = GameObject.Find("Vela3").GetComponent<Image>();

        Color c1 = vela1.color;
        c1.a = 0.05F;
        vela1.color = c1;

        Color c2 = vela2.color;
        c2.a = 0.05F;
        vela2.color = c2;

        Color c3 = vela3.color;
        c3.a = 0.05F;
        vela3.color = c3;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }
        private void PlayerMovement()
        {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        else
        {
            isJumping = false;
        } 
        //gravity
        velocity.y += gravity * Time.deltaTime;
            charController.Move(velocity * Time.deltaTime);
           
            //walk
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                charController.Move(moveDir.normalized * speed * Time.deltaTime);
            }
    

        }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("ColP");
        if (other.CompareTag("Vela") && velas == 0)
        {

            velas = 1;
            GameObject.FindGameObjectWithTag("Vela").SetActive(false);

            Color c1 = vela1.color;
            c1.a = 1F;
            vela1.color = c1;

        }
        else if (other.CompareTag("Vela2") && velas == 1)
        {

            velas = 2;
            GameObject.FindGameObjectWithTag("Vela2").SetActive(false);

            Color c2 = vela2.color;
            c2.a = 1F;
            vela2.color = c2;

        }
        else if (other.CompareTag("Vela3") && velas == 2)
        {

            velas = 3;
            GameObject.FindGameObjectWithTag("Vela3").SetActive(false);

            Color c3 = vela3.color;
            c3.a = 1F;
            vela3.color = c3;

        }


    }

}

