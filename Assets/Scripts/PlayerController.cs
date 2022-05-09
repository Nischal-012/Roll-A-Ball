using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float Speed;
    public TextMeshProUGUI countText;
    private Rigidbody rb;
    private int count;
    private float MovementX;
    private float MovementY;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
       rb=GetComponent<Rigidbody>();
        SetCountText();
    }
    void OnMove(InputValue MovementValue)
    {
        Vector2 MovementVector = MovementValue.Get<Vector2>();
        MovementX = MovementVector.x;
        MovementY = MovementVector.y;

    }
    void SetCountText()
	{
        countText.text = "Count : " + count.ToString();    
	}
	private void FixedUpdate()
	{
		Vector3 Movement = new Vector3 (MovementX,0.0f,MovementY);
        rb.AddForce (Movement * Speed);

	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickups"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
