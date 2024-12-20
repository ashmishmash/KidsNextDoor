using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;



public class FirstPersonControls : MonoBehaviour
{
    [Header("MOVEMENT SETTINGS")]
    [Space(5)]
    // Public variables to set movement and look speed, and the player camera
    public float moveSpeed; // Speed at which the player moves
    public float lookSpeed; // Sensitivity of the camera movement
    public float gravity = -9.81f; // Gravity value
    public float jumpHeight = 1.0f; // Height of the jump
    public Transform playerCamera; // Reference to the player's camera
    public float currentSpeed = 3f;
    // Private variables to store input values and the character controller
    private Vector2 moveInput; // Stores the movement input from the player
    private Vector2 lookInput; // Stores the look input from the player
    private float verticalLookRotation = 0f; // Keeps track of vertical camera rotation for clamping
    private Vector3 velocity; // Velocity of the player
    private CharacterController characterController; // Reference to the CharacterController component

    [Header("LASER SETTINGS")]
    [Space(5)]
    public GameObject laserPrefab; //laser beam prefab
    public bool isLaserOn = false;
    public bool canShoot;
    public bool shooting;
    private bool holdingLaser = true;
    public bool batteryOneGone;
    public bool batteryTwoGone;
    public bool batteryThreeGone;
    public GameObject LaserImage1;
    public GameObject LaserImage2;
    public GameObject LaserImage3;


    [Header("PICKING UP SETTINGS")]
    [Space(5)]
    public Transform holdPosition; // Position where the picked-up object will be held
    private GameObject heldObject; // Reference to the currently held object
    public float pickUpRange = 3f; // Range within which objects can be picked up


    [Header("INTERACT SETTINGS")]
    [Space(5)]
    public float InteractRange = 3f;
    public bool CanInteract;    
    public DialogueFinn dialogue;
    public GameObject dialogueTextFirst;
    public GameObject dialogueTutText;
    public GameObject dialogueBackground;
    public GameObject exclamation;
    private int dialogueCount = 0;

    [Header("CROUCH SETTINGS")]
    [Space(5)]
    public float crouchHeight = 1f; //make short
    public float standingHeight = 2f; //make normal
    public float crouchSpeed = 1.5f; //make slow
    public bool isCrouching = false; //check if crouch
    public bool canCrouch = true;



    [Header ("SOUNDS")]
    [Space (3)]
    public Audio Audio;
    public GameObject Lasersound;
    public bool canMeow;


    [Header("UI")]
    [Space(1)]
    public Image CatFace;

    //Variables 
   
    public bool isSolved = false;

    [Header("Skull Script")]
    [Space(1)]
    public SkullActive SkullScript;

    [Header("Key")]
    [Space(4)]
    public Text KeyTextCounter;
    public int count = 0;
    public int keyCounter = 0;
    public int keyDisplay = 0;

    [Header("Anim")]
    [Space(4)]

    public Animator animator;
    public float Velocity = 0f;
    public bool isWalking;
    public bool isJumping;

    [Header("Partical")]
    [Space(4)]
    public bool landed;
    public ParticleSystem Clouds;
    public GameObject Particals;




    // public UnityEngine.UI.Image[] TutorialImages;
    // public UnityEngine.UI.Image tutorialImage;

    private void Awake()
    {
        // Get and store the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        // Create a new instance of the input actions
        var playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the movement input events
        playerInput.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        playerInput.Player.Movement.canceled += ctx => moveInput = Vector2.zero; // Reset moveInput when movement input is canceled

        // Subscribe to the look input events
        playerInput.Player.LookAround.performed += ctx => lookInput = ctx.ReadValue<Vector2>(); // Update lookInput when look input is performed
        playerInput.Player.LookAround.canceled += ctx => lookInput = Vector2.zero; // Reset lookInput when look input is canceled

        // Subscribe to the jump input event
        playerInput.Player.Jump.performed += ctx => Jump(); // Call the Jump method when jump input is performed

        // Subscribe to the shoot input event
        playerInput.Player.Laser.performed += ctx => Laser(); // Call the Laser method when shoot input is performed

        // Subscribe to the pick-up input event
        playerInput.Player.PickUp.performed += ctx => PickUpObject(); // Call the PickUpObject method when pick-up input is performed

        // Subscribe to the crouch input event
        playerInput.Player.Crouch.performed += ctx => ToggleCrouch(); // Call the ToggleCrouch method when crouch input is performed

        //Subscribe to the sprint input event
        playerInput.Player.Sprint.performed += ctx => Sprint(); // Call the Sprint method when crouch input is performed
        playerInput.Player.Sprint.canceled += ctx => Walk();

        // Subscribe to the interact input event
        playerInput.Player.Interact.performed += ctx => Interact(); // Interact 

        playerInput.Player.Meow.performed += ctx => Meow(); // makes meow sound

    }


    private void Start()
    {
       // MyCo = Timer();
       canMeow = true;
       

    }


    private void Update()
    {
        // Call Move and LookAround methods every frame to handle player movement and camera rotation
        Move();
        LookAround();
        ApplyGravity();
        TimerAleration();
        JumpCheck();
        keyText();
        MeowImage();
        //MeowType();
        Land();
    }

    public void Move()
    {
        // Create a movement vector based on the input
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        // Transform direction from local to world space
        move = transform.TransformDirection(move);
        
        //velocity = currentSpeed * move;
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            isWalking = false;
            // velocity = 0f;
            if (isWalking == false) 
            {
                animator.SetBool("Walkingis", false);
            }
           
            

        }
        else
        {
            //velocity = moveSpeed;
            isWalking = true;
           // animator.SetBool("Walkingis",true);

            if (isWalking == true)
            {
                animator.SetBool("Walkingis",true );
            }
        }

        // Move the character controller based on the movement vector and speed
        characterController.Move(move * currentSpeed * Time.deltaTime);

       
        //animator.SetFloat("speed", currentSpeed);

       
    }

    public void JumpCheck() 
    {
    if (characterController.isGrounded && velocity.y >0) 
        {
            Debug.Log("Grounded");
        }
    }
    public void LookAround()
    {
       
        // Get horizontal and vertical look inputs and adjust based on sensitivity
        float LookX = lookInput.x * lookSpeed;
        float LookY = lookInput.y * lookSpeed;

        //float LookX = lookInput.x * currentlookspeed;
        //float LookY = lookInput.y * currentlookspeed;

        // Horizontal rotation: Rotate the player object around the y-axis
        transform.Rotate(0, LookX, 0);

        

        // Vertical rotation: Adjust the vertical look rotation and clamp it to prevent flipping
        verticalLookRotation -= LookY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        // Apply the clamped vertical rotation to the player camera
        playerCamera.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);

        
    }

    public void ApplyGravity()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f; // Small value to keep the player grounded
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity to the velocity
        characterController.Move(velocity * Time.deltaTime); // Apply the velocity to the character
    }


    public IEnumerator PlayCould() 
    {
        yield return new WaitForSeconds(0.75f);
        Audio.ThudSound.PlayOneShot(Audio.thud);
        Clouds.Play();
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            // Calculate the jump velocity
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //Debug.Log("Jump");
            isJumping = true;
            StartCoroutine(PlayCould());
            animator.SetBool("Jumpingis", true);
        }

       if(isJumping == true) 
        {
            //Debug.Log("jumping");
            StartCoroutine(StopJump());
        }

       if (isJumping == false) 
        {
            //animator.SetBool("Jumpingis", false);
            
        }
    }

    public void Land() 
    {
    if(characterController.isGrounded == true && landed == true) 
        {
            Debug.Log("land");
            Particals.SetActive(true);
            //Audio.SoundEffects.PlayOneShot(Audio.thud);
            Audio.ThudSound.PlayOneShot(Audio.thud);
            StartCoroutine(stopLand());
        }
    }

    public IEnumerator stopLand() 
    {
        landed = false;
        yield return new WaitForSeconds(0f);
    }

    public IEnumerator StopJump() 
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Jumpingis", false);
        isJumping = false;
    }
   // IEnumerator MyCo;

    public void Laser()
    {
        if (holdingLaser == true && canShoot == true) 
        {
           
            if (isLaserOn) 
            {
                //Turn off laser
                laserPrefab.SetActive(false);
                isLaserOn = false;
                shooting = false;
                Lasersound.SetActive(false);
                //StopCoroutine(MyCo);
               
            }
            else
            {
                //Turn on laser
                laserPrefab.SetActive(true);
                isLaserOn = true;
                shooting = true;
                Lasersound.SetActive(true);
                //MyCo = Timer();
                //StartCoroutine(MyCo);
            }
        }

       
    }

  
    public IEnumerator Timer()
    {

        {
            yield return new WaitForSeconds(4f);
            LaserImage1.SetActive(false);
            yield return new WaitForSeconds(3f);
            LaserImage2.SetActive(false);
            yield return new WaitForSeconds(2f);
            LaserImage3.SetActive(false);
            canShoot = false;
            isLaserOn = false;
            shooting = false;
            laserPrefab.SetActive(false);
            yield return new WaitForSeconds(5f);
            canShoot = true;
            LaserImage1.SetActive(true);
            LaserImage2.SetActive(true);
            LaserImage3.SetActive(true);
        }

    }

    public void TimerAleration() 
    {
        if (batteryOneGone == true) 
        {
            Debug.Log("stagec 1");
        }

        if (batteryTwoGone == true) 
        {
            Debug.Log("stagec 2");
        }

        if(batteryThreeGone == true) 
        {
            Debug.Log("stagec 3");
        }
    }

    public void PickUpObject()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.red, 2f);

        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Key")) // check if its a key
            {
                //enable particle effect of some kind 
                //zoom in on key for a while

                
                keyCounter += 1; //will have to make some sort of identifier if we are colour coding
                keyDisplay += 1;
                Destroy(hit.collider.gameObject);
                SkullScript.laserEyeOff =true;
                //hit.collider.gameObject.SetActive(false);
                Audio.SoundEffects.PlayOneShot(Audio.keys);
                Debug.Log("got key");
            }
            // Check if the hit object has the tag "PickUp"
            else if (hit.collider.CompareTag("PickUp")) //narrative elements
            {
                // Pick up the object
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;

                //CHANGE TO ZOOM IN - DONT DROP LASER
            }
            
        }
    }
    public void keyText()
    {
        KeyTextCounter.text = "x" + keyDisplay;

        if(keyDisplay < 0) 
        {
            keyDisplay = 0;
            //Debug.Log("less than zero");
        }
    }

    public void ToggleCrouch()
    {
        if (canCrouch)
        {
            if (isCrouching)
            {
                //Stand up
                characterController.height = standingHeight;
                isCrouching = false;
            }
            else
            {
                //Crouch down
                characterController.height = crouchHeight;
                isCrouching = true;
            }

            //Adjust speed if crouching
            if (isCrouching)
            {
                currentSpeed = crouchSpeed;
            }
            else
            {
                currentSpeed = moveSpeed;
            }
        }
    }

    public void Sprint()
    {
        currentSpeed = moveSpeed * 2;
    }

    public void Walk()
    {
        currentSpeed = moveSpeed;
        
        
    }

    private void Interact()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.red, 2f);

        if (Physics.Raycast(ray, out hit, InteractRange)) 
        {
            if (hit.collider.CompareTag("NPC") && CanInteract == true) 
            {
                Debug.Log("Interact");
                StartCoroutine(InteractWithFin());
            }
        }
    }

    public IEnumerator InteractWithFin() 
    {
        dialogueCount += 1;

        if (dialogueCount == 1)
        {
            exclamation.SetActive(false);
        }

        CanInteract = false;
        currentSpeed = 0;
        lookSpeed = 0;
        canCrouch = false;
        canMeow = false;
        jumpHeight = 0;
        
        yield return new WaitForSeconds(1f);
        
        dialogueTutText.SetActive(true);
        dialogueBackground.SetActive(true);
        dialogueTextFirst.SetActive(true); //enable the first text and tutorial text
        yield return new WaitForSeconds(2f);
        dialogueTutText.SetActive(false);
        //CanInteract = true;
      
    }


    public void MeowImage()
    {
        var CatFaceTransparency = CatFace.color;

        if (canMeow == true)
        {
            CatFaceTransparency.a = 1f;  
            CatFace.color = CatFaceTransparency;
        }

        if (canMeow == false)
        {
            CatFaceTransparency.a = 0.3f;
            CatFace.color = CatFaceTransparency;
        }

    }

    int MeowNumber;
    public void Meow()
    {
        if (canMeow == true)
        {
            //StartCoroutine(Meoww());
            MeowNumber = Random.Range(1, 6);
            //Debug.Log(MeowNumber);

            if (MeowNumber == 1)
            {
                Debug.Log("Meow 1");
                Audio.SoundEffects.PlayOneShot(Audio.Catsound1);
                StartCoroutine(Meoww());
            }

            if (MeowNumber == 2)
            {
                Debug.Log("Meow 2");
                Audio.SoundEffects.PlayOneShot(Audio.Catsound2);
                StartCoroutine(Meoww());
            }

            if (MeowNumber == 3)
            {
                Debug.Log("Meow 3");
                Audio.SoundEffects.PlayOneShot(Audio.Catsound3);
                StartCoroutine(Meoww());
            }

            if (MeowNumber == 4)
            {
                Debug.Log("Meow 4");
                Audio.SoundEffects.PlayOneShot(Audio.Catsound4);
                StartCoroutine(Meoww());
            }

            if (MeowNumber == 5)
            {
                Debug.Log("Meow 5");
                Audio.SoundEffects.PlayOneShot(Audio.Catsound5);
                StartCoroutine(Meoww());
            }
        }
    }

   
    public void MeowType() 
    {
        
    }

    public IEnumerator Meoww() 
    {
        
        canMeow = false;
        //Debug.Log("Meow Meow");
        yield return new WaitForSeconds(1f);
        canMeow = true;
    }
   
}
