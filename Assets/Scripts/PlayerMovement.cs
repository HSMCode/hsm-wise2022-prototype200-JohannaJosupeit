using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum lane { L3, L2, L1, Middle, R1, R2, R3, Right }

public class PlayerMovement : MonoBehaviour
{
    public static bool gameStarted;
    public GameObject startingText;

    public static bool gameOver;
    public GameObject gameOverPanel;

    float xPosition;
    float xPositionLerp;
    public float xValue;
    public lane currentlane;
    public bool ChangeLane, ChangeHeight;

    public Transform GroundCheck;
    public float GroundDistance;
    public LayerMask GroundMask;
    public bool isGrounded;

    public float horizontal, vertical;
    public float Speed, ChangeLaneSpeed, JumpHeight;
    public CharacterController controller;
    
    public Vector3 velocity;
    public float Gravity;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        Speed = 17f;
        controller = GetComponent<CharacterController>();
        xPosition = 0f;
        xValue = 4f;
        currentlane = lane.Middle;
        ChangeLaneSpeed = 5f;
        JumpHeight = 13f;
        GroundDistance = 0.3f;
        Gravity = -20f;
        gameStarted = false;
        gameOver = false;
       
    }

    // Update is called once per frame
    void Update()
    {   
        //press space to start the game
        if(Input.GetKeyDown("space"))
            {
            gameStarted = true;
            Destroy(startingText);
            }
        if (!gameStarted)
        {
            return;
        }

        //GAME OVER
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        //increase speed over time
        Speed += 0.1f * Time.deltaTime;

        //check for input on x and z axis
        ChangeLane = Input.GetButtonDown("Horizontal");
        ChangeHeight = Input.GetButtonDown("Vertical");
        //store input for x and z axis
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        //changing lanes
        if (ChangeLane)
        {
            if (horizontal < 0 && currentlane != lane.L3)
            {
                if (currentlane == lane.R3)
                {
                    xPosition = 2 * xValue;
                    currentlane = lane.R2;
                }
                else if (currentlane == lane.R2)
                {
                    xPosition = xValue;
                    currentlane = lane.R1;
                }
                else if (currentlane == lane.R1)
                {
                    xPosition = 0;
                    currentlane = lane.Middle;
                }
                else if (currentlane == lane.Middle)
                {
                    xPosition = -xValue;
                    currentlane = lane.L1;
                }
                else if (currentlane == lane.L1)
                {
                    xPosition = 2 * -xValue;
                    currentlane = lane.L2;
                }
                else if (currentlane == lane.L2)
                {
                    xPosition = 3 * -xValue;
                    currentlane = lane.L3;
                }
            }

            if (horizontal > 0 && currentlane != lane.R3)
            {
                if (currentlane == lane.L3)
                {
                    xPosition = 2 * -xValue;
                    currentlane = lane.L2;
                }
                else if (currentlane == lane.L2)
                {
                    xPosition = -xValue;
                    currentlane = lane.L1;
                }
                else if (currentlane == lane.L1)
                {
                    xPosition = 0;
                    currentlane = lane.Middle;
                }
                else if (currentlane == lane.Middle)
                {
                    xPosition = xValue;
                    currentlane = lane.R1;
                }
                else if (currentlane == lane.R1)
                {
                    xPosition = 2 * xValue;
                    currentlane = lane.R2;
                }
                else if (currentlane == lane.R2)
                {
                    xPosition = 3 * xValue;
                    currentlane = lane.R3;
                }
            }

        }
        //GroundCheck
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

       //smooth changing of lanes
        xPositionLerp = Mathf.Lerp(xPositionLerp, xPosition, Time.deltaTime * ChangeLaneSpeed);
        Vector3 moveVector = new Vector3((xPositionLerp - transform.position.x), (velocity.y * Time.deltaTime), Speed * Time.deltaTime);
        
        //rolling and jumping
        Roll();
        Jump();

        controller.Move(moveVector);
    }

    public void Roll()
    {
        if (vertical < 0)
        {
            velocity.y = -JumpHeight;
            Debug.Log("Rolling");
        }
    }

    public void Jump()
    {
        if (isGrounded && velocity.y < 0)
        { velocity.y = -1f; }

        if (isGrounded && ChangeHeight)
            if (vertical > 0)
            {
                Debug.Log("Jumping");
                velocity.y = JumpHeight;
            }
            
            else
            { }
        else
        {
                velocity.y += Gravity * Time.deltaTime;
        }
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag=="Obstacle")
        {
            gameOver = true;
        }
    }


}
