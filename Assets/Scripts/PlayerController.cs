using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float walkSpeed = 2f;
    float runSpeed = 4f;
    new Transform camera;
    public float sensitivity = 350f;


    float headRotation = 0f;
    float headRotationLimit = 90f;



    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        mouseMovement();
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

    void mouseMovement()
    {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;


        transform.localEulerAngles += new Vector3(0f, x, 0f);
        headRotation += y;
        headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
        camera.localEulerAngles = new Vector3(headRotation, 0f, 0f);
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
