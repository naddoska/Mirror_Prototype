using Mirror;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class Player1_Controller : NetworkBehaviour
{
    public Rigidbody Player1;
    public float horizontalInput;
    public float rotationInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float height = 1.8f;
    private bool isfirstperson = true; 

    // Update is called once per frame
    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3( 0, height, 0);
        Camera.main.transform.localRotation = Quaternion.identity;
    }

    private void Update()
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
        //if (Input.GetMouseButtonDown(0)) mousemovement for later
        //{
            //rotationInput = Input.
        //}
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        // transform.Rotate
    }

    private void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isfirstperson)
            {
                Camera.main.transform.localPosition = new Vector3(0, 2, -1);
                Debug.Log("Aussen");
                isfirstperson = false;
            }
            else
            {
                Camera.main.transform.localPosition = new Vector3(0, height, 0);
                Debug.Log("Innen");
                isfirstperson = true;
            }
        }
    }


    
}
