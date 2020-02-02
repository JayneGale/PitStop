using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float bounceMultiplier;
    public float bounceSpeed;
    public bool canMove;
    public Vector2 position;
    public Animator _anim;

    Vector3 bounceLocation;

    public void Fire(InputAction.CallbackContext context)
    {
        //Debug.Log("Fire!");
        GetComponent<PlayerPickUp>().Fire();
    }
    public void Move(InputAction.CallbackContext context){

        var moveDirection = context.ReadValue<Vector2>();
        position = moveDirection * speed * Time.deltaTime;
        if (gameObject.activeSelf)
        {
            if (position != Vector2.zero)
            {
                //print(gameObject.name);
                 _anim.SetBool("Walking", true);
                //print(gameObject.name);
                var v3Position = new Vector3(position.x, 0, position.y);
                transform.rotation = Quaternion.LookRotation(v3Position);
            }
            else
            {
                _anim.SetBool("Walking", false);
            }
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += new Vector3(position.x * speed, 0, position.y * speed);           
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            canMove = false;
            Debug.Log("Hit");
            Debug.Log(collision.contacts[0].normal);
            bounceLocation = transform.position + (collision.contacts[0].normal * bounceMultiplier);
            Debug.Log(bounceLocation);
            StartCoroutine("Bouncing");
        }
    }

    IEnumerator Bouncing()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, bounceLocation, bounceSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, bounceLocation) < 0.1f)
            {
                canMove = true;
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
