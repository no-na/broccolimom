using UnityEngine;
using System.Collections;


public class DemoScene : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
    //health config
    public float health = 6f;

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




	void Awake()
	{
		_animator = GetComponent<Animator>();
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
		if(gameObject.GetComponent<Animator>().GetBool("die") == true)
		{
			normalizedHorizontalSpeed = 0;
			_animator.Play( Animator.StringToHash( "die" ) );

		}
		else if( Input.GetAxisRaw("Horizontal"+controllerName)>0 )
		{
			
			normalizedHorizontalSpeed = 1;
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			
			_attack.Aim();
			
			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else if( Input.GetAxisRaw("Horizontal"+controllerName)<0 )
		{
			normalizedHorizontalSpeed = -1;
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			_attack.Aim();
			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else
		{
			normalizedHorizontalSpeed = 0;

			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Idle" ) );
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
			_animator.Play( Animator.StringToHash( "Jump" ) );
		}


		// apply horizontal speed smoothing it
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		_controller.move( _velocity * Time.deltaTime );
	}
    //collisions!!!!
    void OnTriggerEnter2d(Collider2D other)
    {
        string strOther = other.gameObject.GetType().ToString();
        if (strOther == "EnemyBullet")
        {
            health -= 1;
        }
        else if (strOther == "Shark")
        {
            health -= 1;
        }
    }
}
