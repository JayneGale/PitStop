using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool canMove;
    public Vector2 position;
    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
        GetComponent<PlayerPickUp>().Fire();
    }
    public void Move(InputAction.CallbackContext context){
        var moveDirection = context.ReadValue<Vector2>();
        position = moveDirection * speed * Time.deltaTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += new Vector3(position.x * speed, 0, position.y * speed);           
        }
    }
}
