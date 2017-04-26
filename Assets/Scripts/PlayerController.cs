using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;

	public float speed;
	public Text countText;
	public Text winText;

	// Use this for initialization
	void Start () {
		count = 0;
		rb = GetComponent<Rigidbody> ();
		setCountText ();
		winText.text = "";
	}

	void Update(){
		Vector3 movement = new Vector3 (0, Input.GetAxis("Horizontal"), 0);
		//arrow.transform.Rotate (movement * Time.deltaTime * speed);
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pickup")){
			other.gameObject.SetActive(false);
			count = count + 1;
			setCountText ();
		}
	}

	void setCountText (){
		countText.text = "Count: " + count.ToString ();
		if (count >= 5) {
			winText.text = "You Win";
		}
	}

}
