using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	public static PlayerMovement instance;
	public float speed = 6f;

	Vector3 movement;
	Animator animator;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	[HideInInspector]
	public float x, y, z;

	void Awake()
	{
		instance = this;

		floorMask = LayerMask.GetMask ("Floor");
		animator = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	public void savepos()
	{
		saveandload.instance.setxAxis(x);
		saveandload.instance.setyAxis(y);
		saveandload.instance.setzAxis(z);

		//Debug.Log(saveandload.instance.getxAxis());
		
		//Debug.Log(saveandload.instance.getyAxis());
		
		//Debug.Log(saveandload.instance.getzAxis());
		
	}

	public void loadpos(float x, float y, float z)
	{
		transform.position = new Vector3(x, y, z);
	}

	void FixedUpdate()
	{
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move(h, v);
		Turning();
		Animating(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0;

			var rotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(rotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		animator.SetBool("IsWalking", walking);
	}

}