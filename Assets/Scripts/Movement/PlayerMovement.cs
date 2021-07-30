using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = .6f;
    public LayerMask groundMask;
    public Light flashlight;
    public GameObject flashlightLimiter;
    private bool toggle;
    [SerializeField]float cooldown = 0;
    private float nextTime = 0;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            toggle = !toggle;
        if (toggle) {
            flashlightLimiter.SetActive(false);
            flashlight.enabled = true;
            flashlight.gameObject.SetActive(true);
        }
        else
        {
            flashlightLimiter.SetActive(true);
            StartCoroutine(Testezinho());
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator Testezinho()
    {
        yield return new WaitForSecondsRealtime(0.0000001f);
        flashlight.gameObject.SetActive(false);
        flashlight.enabled = false;
    }
}
