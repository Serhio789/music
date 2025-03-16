using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;
    private CharacterController controller;

    public AudioClip[] footstep;
    AudioSource playerAudio;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("Run", true);
            controller.Move(moveSpeed * Time.deltaTime * direction);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    void Footstep()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Player Footsteps");
    }
}
