using UnityEngine;
using FMOD.Studio;
using JetBrains.Annotations;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] float speed = 15f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;

    //audio
    private EventInstance playerFootsteps;

    Vector3 velocity;
    bool isGrounded;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        playerFootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.playerFootsteps);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movement();

        }
        //UpdateSound();



    }
    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        UpdateSound();



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * (speed + 0.5f) * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void UpdateSound()
    {
        if( controller.velocity.magnitude > 2.5f && isGrounded)
        {
            // start footsteps event if it's not already playing
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if(playbackState != PLAYBACK_STATE.PLAYING)
            {
                playerFootsteps.start();
            }
        }
        // otherwise stop the footsteps event
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
    public void EnableMovement()
    {
        canMove = true;
    }
    public void DisableMovement()
    {
        canMove = false;
    }
}
