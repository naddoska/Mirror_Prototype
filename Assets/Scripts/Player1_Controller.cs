using Mirror;
using UnityEngine;


public class Player1_Controller : NetworkBehaviour
{
    public Rigidbody Player1;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
 
    // Update is called once per frame
    void FixedUpdate()
    {
        if(isLocalPlayer) 
        CmdMove();
    }

    private void CmdMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    
}
