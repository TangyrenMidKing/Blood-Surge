using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float walkSpeed = 2f;
    float runSpeed = 4f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if user is holding the left shift key
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveCharacter(runSpeed);
        }
        else
        {
            moveCharacter(walkSpeed);
        }
    }


    void moveCharacter(float currentSpeed)
    {
        // Lets the character body move left and right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * currentSpeed);

        // Lets the character body move forward and back
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * currentSpeed);
    }
}
