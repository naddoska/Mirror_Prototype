using Mirror;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class Player1_Controller : NetworkBehaviour
{
    public Rigidbody Player1;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    private float height = 1.8f;
    private float rotationInputX;
    private float rotationInputY;
    private float rotationSpeed = 1.5f;

    private bool isFirstPerson = true;
  

    // Update is called once per frame
    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3( 0, height, 0);
        Camera.main.transform.localRotation = Quaternion.identity;
        
    }

    private void Update() //Update for Movement!
    {
        if (isLocalPlayer)
        {
            CameraSwitch();
            CmdMove();
        }
    }



    private void CmdMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rotationInputX += Input.GetAxis("Mouse X") * rotationSpeed;
        rotationInputY += Input.GetAxis("Mouse Y") * rotationSpeed;
        // if (Input.GetMouseButtonDown(0))
            
            if (Input.GetMouseButton(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                transform.localRotation = Quaternion.Euler(0, rotationInputX, 0);
                Camera.main.transform.localRotation = Quaternion.Euler(-rotationInputY, 0, 0);
            }
           else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        
    }

    private void CameraSwitch() 
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isFirstPerson)
            {
                Camera.main.transform.localPosition = new Vector3(0, 2, -1);
                isFirstPerson = false;
            }
            else
            {
                Camera.main.transform.localPosition = new Vector3(0, height, 0);
                isFirstPerson = true;
            }
        }
    }


    
}
