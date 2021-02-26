using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SerializeField allows us to keep this private but still edit the value from the UI
    [SerializeField] private float speed;

    private PlayerControls playerControls;
    
    private Rigidbody2D rb;

    // Script lifecycle flowchart: https://docs.unity3d.com/Manual/ExecutionOrder.html 
    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Execute attack function when attack input performed
        playerControls.Default.Attack.performed += _ => Attack(); 
    }

    private void Attack() {
        // have the player attack any enemy or attackable entity immediately in-front of it

        // make sure the user isn't already attacking (isAttacking) - example. 
    }

    // Update is called once per frame
    void Update()
    {

        // read horizontal movement value 
        float horizontalMovementInput = playerControls.Default.Horizontal.ReadValue<float>();
        // read vertical movement value
        float verticalMovementInput = playerControls.Default.Vertical.ReadValue<float>();

        // get current player position
        Vector3 currentPosition = transform.position;

        // update player horizontal position
        currentPosition.x += horizontalMovementInput * speed * Time.deltaTime;

        // update player vertical position
        currentPosition.y += verticalMovementInput * speed * Time.deltaTime;

        // move the player
        transform.position = currentPosition;
         

    }
}
