using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
	public GameObject winTextObject;

    public AudioSource pop;

    private Rigidbody rb;
    private int count; 

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        pop=GetComponent<AudioSource>();
        
        rb = GetComponent<Rigidbody>();
        count=0;
        SetCountText ();

                // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
         winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            count=count+1;
            pop.Play();
            SetCountText ();
        }
        
    }
     void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 11) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
	}

}