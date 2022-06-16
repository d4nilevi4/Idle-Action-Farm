using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private DynamicJoystick _joystick;
	[SerializeField] private float _turnSpeed;
	[SerializeField] private float _speedDurringCollection;
	[SerializeField] private float _runningSpeed;

	private float _speed;
	
	private Rigidbody _rigidbody;
	private Animator _animator;

	private float _turnAmount;
	private Vector3 _direction;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_animator = GetComponent<Animator>();
		_speed = _runningSpeed;
	}


	private void FixedUpdate()
	{
		float horizontal = _joystick.Horizontal;
		float vertical = _joystick.Vertical;

		_direction = vertical * Vector3.forward + horizontal * Vector3.right;

		

		if(Mathf.Abs(_direction.magnitude) > 0.25f)
        {
			Move(_direction);
		} else
        {
			_animator.SetBool("isRun", false);
		}
	}

	public void Move(Vector3 move)
	{
		_animator.SetBool("isRun", true);
		if (move.magnitude > 1f) move.Normalize();

		_rigidbody.velocity = move * _speed;

		move = transform.InverseTransformDirection(move);
		_turnAmount = Mathf.Atan2(move.x, move.z);

		TurnRotation();
	}

	void TurnRotation()
	{
		transform.Rotate(0, _turnAmount * _turnSpeed * Time.deltaTime, 0);
	}

	public void SetRunningSpeed()
    {
		_speed = _runningSpeed;
	}

	public void SetSpeedDuringCollection()
    {
		_speed = _speedDurringCollection;
	}
}