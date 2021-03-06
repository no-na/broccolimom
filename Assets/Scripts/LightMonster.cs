using UnityEngine;
using System.Collections;

public class LightMonster : MonoBehaviour {


	public bool direction = false;
	//true = rightwards motion; false = leftwards motion; defaults to leftwards

	private Rigidbody2D rb2d;

	//gameobjects for the two characters go here
	public GameObject target1;
	public GameObject target2;

	//how fast the monster moves
	public float speed;

	//a slingshot takes away 2 health points; a shield bash takes away 1
	public int health;

	public string playerTag;
	public string slingshotTag;
	public string shieldTag;
	public string cameraTag;
	public string platformTag;
	public string groundTag;
	public string jumpTag;

	[SerializeField]
	private bool isAwake = false;

	public float jumpTime;
	[SerializeField]
	private float jumpTimer = 0f;

	public bool isAttacking = false;
	[SerializeField]
	private bool isGrounded = true;



	public float attackTime;
	[SerializeField]
	private float attackTimer;

	public bool isHeavy;

	public float jumpForce;

	// Use this for initialization
	void Start () {

		//grab rigidbody
		rb2d = GetComponent<Rigidbody2D>();


		attackTimer = 0f;
	
	}

	//this method starts the monster's motion
	void Move()
	{
		if (!isAwake) {
			if (!isHeavy) {
				Vector2 dir = new Vector2 ();

				if (direction) {
					//direction is rightwards, positive x
					dir = Vector2.right;
				} else {
					//direction is leftwards, negative x
					dir = Vector2.left;
				}

				rb2d.velocity = dir * speed;
			}
		}

		isAwake = true;
		isGrounded = true;


	}

	void LoseHealth(int healthLost)
	{
		health -= healthLost;
		if (health <= 0) {
		
			Die();
		}
	}

	void Attack()
	{
		isAttacking = true;
		attackTimer = 0f;

	}

	// Update is called once per frame
	void Update () {
		
		if (health <= 0) {
			Die ();
		}


		//attack timer
		if (isAttacking) {
			attackTimer += Time.deltaTime;
		}
		if (attackTimer >= attackTime) {
			isAttacking = false;
			attackTimer = 0f;
		}
		if (!isGrounded) {
			print("not grounded");
			//check to see if is grounded
			RaycastHit2D rh = Physics2D.Raycast (this.transform.position, Vector2.down, 10f);
			if (rh.collider != null) {
				print("rh.collider not null");
				if ((rh.collider.CompareTag (groundTag) || rh.collider.CompareTag (groundTag)) && ((rh.collider.gameObject.transform.position.y - this.transform.position.y) < 1)){
					isGrounded = true;
					jumpTimer = 0f;
					isAwake = false;
					Move ();
				}
			}
		} else {
			jumpTimer += Time.deltaTime;
		}
		if (isGrounded && (jumpTimer >= jumpTime)) {
			//Jump ();
		}

	
	}


	void Jump()
	{
		if (isAwake && !isHeavy) {
			rb2d.AddForce (new Vector2 (rb2d.velocity.x * speed, 1f * jumpForce));
			isGrounded = false;
			jumpTimer = 0f;
		}
	}


	private bool jumpCast()
	{
		float x = 1;

		if (!direction) {
			x = -1;
		}


		RaycastHit2D r = Physics2D.Raycast (new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1f), new Vector2 (x, 0));

			if (r.collider != null) {
				if (r.collider.gameObject != null) {
					if (r.collider.gameObject.CompareTag (platformTag)) {
						return true;
					} else
						return false;
				}else
					return false;
			}else
				return false;
	

	}

	void Die()
	{

		Destroy (this.gameObject);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		print("collision");

		//something has collided with the monster

		//if it is a player
		if (other.gameObject.CompareTag (playerTag)) {
			if (!isAttacking) {
			
				Attack ();
			
			}

		}


		//if it's a camera, start moving the enemy
		if (other.gameObject.CompareTag (cameraTag)) {
			print("compared tag with cameratag");
			Move();
		}


		//if it is a shield
		if (other.gameObject.CompareTag (shieldTag)) {
			LoseHealth (1);
		
		}

		//if it is a platform
		if (other.gameObject.CompareTag (platformTag)) {
			//Jump ();

		}

		if (other.gameObject.CompareTag (jumpTag)) {
			Jump ();

		}

		//if it is a slingshot
		if (other.gameObject.CompareTag (slingshotTag)) {
			LoseHealth (2);

		}




	}
}
