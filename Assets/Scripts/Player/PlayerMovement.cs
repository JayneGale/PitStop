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
    public GameObject[] playerModels;
    int modelNo = 0;
    public Animator _anim;

    public float currentUnwieldyFactor;
    public float randomMovementCheckInterval = 2.5f;
    public float randomMovementDuration = 0.7f;
    bool willGenerateRandomMovementVector;
    bool isAddingRandomMovement;
    float randomMovementDurationTimer;
    float randomMovementCheckIntervalTimer;
    Vector2 randomMovement;

    Vector3 bounceLocation;

    public void Fire(InputAction.CallbackContext context)
    {
        GetComponent<PlayerPickUp>().Fire();
    }
    public void Move(InputAction.CallbackContext context){

        var moveDirection = context.ReadValue<Vector2>();
        UpdateMovementTimer();
        CheckForRandomVector();
        position = moveDirection * speed * Time.deltaTime;
        if (gameObject.activeSelf)
        {
            if (position != Vector2.zero)
            {
                position += randomMovement * Time.deltaTime;
                 _anim.SetBool("Walking", true);
                var v3Position = new Vector3(position.x, 0, position.y);
                transform.rotation = Quaternion.LookRotation(v3Position);
            }
            else
            {
                _anim.SetBool("Walking", false);
            }
        }
        
    }
    public void Change(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (modelNo + 1 < playerModels.Length)
            {
                modelNo++;
            }
            else
            {
                modelNo = 0;
            }
            bool carrying = _anim.GetBool("Carry");
            for (int i = 0; i < playerModels.Length; i++)
            {
                playerModels[i].SetActive(false);
            }
            playerModels[modelNo].SetActive(true);
            _anim = playerModels[modelNo].GetComponent<Animator>();
            GetComponent<PlayerPickUp>()._anim = playerModels[modelNo].GetComponent<Animator>();
            _anim.SetBool("Carry", carrying);
        }
    }

    Vector2 GenerateRandomMovementVector()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * currentUnwieldyFactor;
    }

    void CheckForRandomVector()
    {
        if (randomMovementCheckIntervalTimer < randomMovementCheckInterval)
        {
            randomMovementCheckIntervalTimer += Time.deltaTime;
            willGenerateRandomMovementVector = randomMovementCheckIntervalTimer > randomMovementCheckInterval;
        }
        if (willGenerateRandomMovementVector)
        {
            randomMovement = GenerateRandomMovementVector();
            willGenerateRandomMovementVector = false;
            isAddingRandomMovement = true;
            randomMovementDurationTimer = 0f;
        }
    }
    void UpdateMovementTimer()
    {
        randomMovementDurationTimer += Time.deltaTime;
        if(isAddingRandomMovement && randomMovementDurationTimer > randomMovementDuration)
        {
            isAddingRandomMovement = false;
            randomMovementCheckIntervalTimer = 0;
            randomMovement = new Vector2();
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
            bounceLocation = transform.position + (collision.contacts[0].normal * bounceMultiplier);
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
