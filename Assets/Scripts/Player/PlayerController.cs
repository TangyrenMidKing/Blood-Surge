using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float walkSpeed = 3f;
    float runSpeed = 6f;
    float boostWalkSpeed = 6f;
    float boostRunSpeed = 8f;
    public bool hasBoostSpeed;
    float runAudio = 2.0f;
    float walkAudio = 1.5f;
    public AudioClip playerMovement;
    AudioSource movementAudio;



    // Start is called before the first frame update
    void Start()
    {
        movementAudio = GetComponent<AudioSource>();
        movementAudio.playOnAwake = false;
        hasBoostSpeed = false;
    }

    private void Update()
    {
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Applies appropiate speed to movement depending if character is holding left shift and if character has the boost perk
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Mouse0))
        {
            MoveCharacter(hasBoostSpeed ? boostRunSpeed : runSpeed);
        }
        else
        {
            MoveCharacter(hasBoostSpeed ? boostWalkSpeed : walkSpeed);
        }
    }


    // moves character base on input, takes in speed as param
    void MoveCharacter(float currentSpeed)
    {
        // Lets the character body move left and right
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * currentSpeed);

        // Lets the character body move forward and back
        verticalInput = Input.GetAxisRaw("Vertical");
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * currentSpeed);


        Vector3 movementVector = new Vector3(horizontalInput, 0, verticalInput);
        movementVector.Normalize();

        transform.Translate(movementVector * Time.deltaTime * currentSpeed);


        // check if character is moving
        if(horizontalInput!=0 || verticalInput!=0)
        {
            PlayMovementAudio(currentSpeed);

        }


    }

    // Coroutine used as a countdown timer. Applies speed boost to character for 7 seconds
    IEnumerator BoostSpeedCountDownRoutine()
    {
        yield return new WaitForSeconds(7f);

        hasBoostSpeed = false;

    }

    // If player runs into the speed boost perk then destroy the speed boost object and start coroutine for countdown
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost") && hasBoostSpeed != true)
        {
            hasBoostSpeed = true;
            Destroy(other.gameObject);
            StartCoroutine(BoostSpeedCountDownRoutine());
        }
    }

    void PlayMovementAudio(float pitchLevel)
    {

        if (movementAudio.isPlaying == false)
        {
            if (pitchLevel >= 4)
            {
                movementAudio.pitch = runAudio;
            }
            else
            {
                movementAudio.pitch = walkAudio;
            }
            
            movementAudio.PlayOneShot(playerMovement, 0.5f);
        }
    }


}
