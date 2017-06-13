using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class DemoScene : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
    //Tom's additions - identifiers, powerup booleans, health
    public int health;
	[SerializeField]
	private Text healthUI;

	public string character;
	public bool hasPowerup = false;
	public Powerup activePowerup;
	public float powerupEndTime;
	public bool invincible = false;


	[SerializeField]
	private string controllerName = "";

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;
	
	[SerializeField]
	private Attack _attack; //controls attacking, aiming
	
	[SerializeField]
	private AudioSource audioSource;
	[SerializeField]
	private List<AudioClip> audioSources;
	
	public GameManager gameManager;

    

	void Awake()
	{
		_animator = GetComponent<Animator>();
        _animator.SetInteger("state", 0);
		_controller = GetComponent<CharacterController2D>();

		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;
	}


	#region Event Listeners

	void onControllerCollider( RaycastHit2D hit )
	{

		// bail out on plain old ground hits cause they arent very interesting
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent( Collider2D col )
	{
		Debug.Log( "onTriggerEnterEvent: " + col.gameObject.name );
		
		
		//powerup collision
		if (col.gameObject.tag == "Powerup") {
			Powerup powerup = col.gameObject.GetComponent<Powerup> ();
			powerup.SetPlayer(gameObject);
			if(powerup.IsRelevant()){
				activePowerup = powerup;
				powerup.ApplyPowerup();
				powerupEndTime = 400f;
				hasPowerup = true;
			}
		}
	}


	void onTriggerExitEvent( Collider2D col )
	{
		Debug.Log( "onTriggerExitEvent: " + col.gameObject.name );
	}

	#endregion


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;

		if( _controller.isGrounded )
			_velocity.y = 0;
		if( Input.GetAxisRaw("Horizontal"+controllerName)>0 )
		{
			
			normalizedHorizontalSpeed = 1;
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			
			_attack.Aim();
			
			if( _controller.isGrounded )
                _animator.SetInteger("state", 1);
        }
		else if( Input.GetAxisRaw("Horizontal"+controllerName)<0 )
		{
			normalizedHorizontalSpeed = -1;
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			_attack.Aim();
			if( _controller.isGrounded )
                _animator.SetInteger("state", 1);
        }
		else
		{
			normalizedHorizontalSpeed = 0;

            if (_controller.isGrounded)
                _animator.SetInteger("state", 0);
		}
		
		if( Input.GetAxisRaw("Vertical"+controllerName)>0)
		{
			_attack.Aim();
		}
		else if( Input.GetAxisRaw("Vertical"+controllerName)<0)
		{
			_attack.Aim();
		}
		
		
		
		if( Input.GetButton("Fire"+controllerName))
		{
			_attack.DoAttack();
		}
		else
		{
			_attack.CancelAttack();
		}


		// we can only jump whilst grounded
		if( _controller.isGrounded && Input.GetButtonDown("Jump"+controllerName) && gameObject.GetComponent<Animator>().GetBool("die") == false)
		{
			_velocity.y = Mathf.Sqrt( 2f * jumpHeight * -gravity );
			audioSource.clip = audioSources[0];
			audioSource.Play();
            _animator.SetInteger("state", 2);
        }


		// apply horizontal speed smoothing it
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		_controller.move( _velocity * Time.deltaTime );

		if (health == 0) {
			Debug.Log("dead");
		}


	}
	
	void FixedUpdate(){
		//powerup duration checks
		if(hasPowerup){
			powerupEndTime -= 1;
			if (powerupEndTime <= 0) {
				//turn off invincible
				if(invincible == true){
					invincible = false;
				}
				//turn off reflection

				//turn off rapid fire

				//turn off scattershot
				activePowerup.RemovePowerup();
				hasPowerup = false;
			}
		}
	}


	//general damage
	void DamagePlayer (int damage){
		if(invincible == false){
			health -= damage;
			healthUI.text = health.ToString();
			if (health <= 0) {
				healthUI.text = "0";
				gameManager.PlayerDeath(gameObject);
				Destroy(gameObject);
			}
		}
	}

    //collisions
    void OnCollisionEnter2D(Collision2D other)
    {
		//enemy collisions
		if (other.gameObject.tag == "Enemy") {
			print("enemy collision");
			//add if statements to check enemy type and change how much damage is done
			if (other.gameObject.GetComponent<Enemy> ().eType == "EnemyBullet") {
				Debug.Log ("enemy bullet hit");
				DamagePlayer (1);
				Destroy (other.gameObject);
			} else if (other.gameObject.GetComponent<Enemy> ().eType == "PufferFish") {
				//code goes here
			} else if (other.gameObject.GetComponent<Enemy> ().eType == "Shark") {
				DamagePlayer (2);
				Destroy (other.gameObject);
			} else if (other.gameObject.GetComponent<Enemy> ().eType == "Anglerfish") {
				DamagePlayer (2);
				Destroy (other.gameObject);
			}
			//DamagePlayer (1);
			//Destroy (other.gameObject);
		}

		
    }
}
