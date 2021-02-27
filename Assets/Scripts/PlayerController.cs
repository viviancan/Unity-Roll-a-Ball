using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    private int count;
    public TextMeshProUGUI countText; // ref to UI text component
    public GameObject winTextObject; 

    // Start is called before the first frame update
    // check every frame for player input
    // apply that to player game object as movement
    // fixed update <= called just before physics calculations
    void Start()
    {
        count = 0; //sets initial count to zero
        rb = GetComponent<Rigidbody>();

        setCountText();

        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementVal)
    {
        //getting input value from player
        // gets vector 2 data from movement value and stores it into the vector2 variable = movementVector
        Vector2 movementVector = movementVal.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //if the game object has a pickup tag, set active status to false
            other.gameObject.SetActive(false);
            
            //every time "coin" gets picked up add 1 to the count
            count += 1;

            setCountText();
        }

    }
}
