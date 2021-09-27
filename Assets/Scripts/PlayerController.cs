using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float walkSpeed = 2f;
    float runSpeed = 4f;
    float boostWalkSpeed = 4f;
    float boostRunSpeed = 6f;
    bool hasBoostSpeed;



    // Start is called before the first frame update
    void Start()
    {
        hasBoostSpeed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Applies appropiate speed to movement depending if character is holding left shift and if character has the boost perk
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveCharacter(hasBoostSpeed ? boostRunSpeed : runSpeed);
        }
        else
        {
            moveCharacter(hasBoostSpeed ? boostWalkSpeed : walkSpeed);
        }
    }


    // moves character base on input, takes in speed as param
    void moveCharacter(float currentSpeed)
    {
        // Lets the character body move left and right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * currentSpeed);

        // Lets the character body move forward and back
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * currentSpeed);
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
        if (other.CompareTag("SpeedBoost"))
        {
            hasBoostSpeed = true;
            Destroy(other.gameObject);
            StartCoroutine(BoostSpeedCountDownRoutine());
        }
    }


}
