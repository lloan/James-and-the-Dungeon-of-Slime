using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SerializeField allows us to keep this private but still edit the value from the UI
    [SerializeField] private float speed;

    private PlayerControls playerControls;
    

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.log("Move values...");
        Debug.log(playerControls.Land.Move);

        // read movement value 
        float movementInput = playerControls.Land.Move.ReadValue<float>();
        // get current player position
        Vector3 currentPosition = transform.position;

        currentPosition.x += movementInput * speed * Time.deltaTime;

        transform.position = currentPosition;
        // move the player

    }
}
