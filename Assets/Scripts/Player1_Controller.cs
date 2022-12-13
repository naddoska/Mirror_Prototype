using Mirror;
using UnityEngine;


public class Player1_Controller : NetworkBehaviour
{
    public Rigidbody Player1;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    private float height = 1.8f;
    private float rotationInputVertical;
    private float rotationInputHorizontal;
    private float rotationSpeed = 1.5f;
    private float mouseStartX;
    private float mouseStartY;
    private float rotationMaxDown = 42.0f;
    private float rotationMaxUp = 45.0f;

    private bool isFirstPerson = true;


    // Update is called once per frame
    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, height, 0);
        Camera.main.transform.localRotation = Quaternion.identity;

    }
    private void FixedUpdate()
    {
     if (isLocalPlayer)
        {
            CmdMove();
        }
    }
    private void Update() //Update for Movement!
    {
        if (isLocalPlayer)
        {
            CameraSwitch();
            MouseNotClicked();
        }
    }
    private void CmdMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        if (Input.GetMouseButtonDown(0))
        {
            mouseStartX = Input.GetAxis("Mouse X");
            mouseStartY = Input.GetAxis("Mouse Y");
        }

        if (Input.GetMouseButton(0))
        {
            rotationInputVertical += (Input.GetAxis("Mouse X") - mouseStartX) * rotationSpeed;
            rotationInputHorizontal += (Input.GetAxis("Mouse Y") - mouseStartY) * rotationSpeed;
            rotationInputHorizontal = Mathf.Clamp(rotationInputHorizontal, -rotationMaxDown, rotationMaxUp);
            transform.localRotation = Quaternion.Euler(0, rotationInputVertical, 0);
            Camera.main.transform.localRotation = Quaternion.Euler(-rotationInputHorizontal, 0, 0);
            Cursor.visible = false;
        }

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

    }

    private void MouseNotClicked()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.visible = true;
        }
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