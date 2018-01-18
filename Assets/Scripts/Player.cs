using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    //Public Editor variables
    public Collider BoundsCollider;
    public float JumpForce = 5f;
    public float MovementSpeed = 2f;

    public KeyCode JumpKey = KeyCode.Space;

    private bool down = true;

    public bool Down
    {
        get { return down; }
        set
        {
            down = value;
            rigid.velocity = Vector3.zero;
        }
    }

    private bool isOnGround;

    public bool IsGrounded
    {
        get { return isOnGround; }
    }

    private Rigidbody rigid;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(JumpKey))
        {
            Jump(false);
        }
	}

    private void FixedUpdate()
    {
        //Vector3 vel = Vector3.one;

        //vel *= Input.GetAxis("Horizontal") * MovementSpeed;

        //vel.x *= Input.GetAxis("Horizontal") * MovementSpeed;
        //vel.y *= Input.GetAxis("Vertical") * MovementSpeed;


        //rigid.velocity = vel;

        Vector3 pos = this.transform.position;

        pos.x += Input.GetAxis("Horizontal") * MovementSpeed;
        pos.z += Input.GetAxis("Vertical") * MovementSpeed;

        this.transform.position = pos;

        CheckIfGrounded();
    }

    public void Jump(bool shouldJumpInAir = false)
    {
        if (!IsGrounded && !shouldJumpInAir)
            return;

        rigid.velocity = Vector3.zero;

        rigid.AddForce(Down ? JumpForce * Vector3.up : JumpForce * Vector3.down, ForceMode.VelocityChange);
    }

    private void CheckIfGrounded()
    {
        if (BoundsCollider == null)
            return;

        RaycastHit hit;

        bool b = Physics.Raycast(transform.position, Down ? Vector3.down : Vector3.up, out hit, BoundsCollider.bounds.extents.y + 0.1f);

        isOnGround = b;
    }
}
