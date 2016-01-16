using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float speed;
    public float speedMax;
    public float speedMin;
    public float yawSpeed;
    public float pitchSpeed;
    public float rollSpeed;
    private Rigidbody rigid;
    private Vector3 lift;
    public float liftBooster;


	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}

    void Update()
    {
        this.transform.position += transform.forward * speed;
        if (Input.GetKey(KeyCode.W))
        {
            speed += (0.1f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed -= (0.2f * Time.deltaTime); 
        }
        else
        {
            if (speed > speedMin)
            {
                speed -= (0.2f * Time.deltaTime);
            }
        }
        //Control Yaw
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, yawSpeed, 0));
        } else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, -yawSpeed, 0));
        }

        //Control Roll
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetAxis("Mouse X") > 0)
        {
            this.transform.Rotate(new Vector3(0, 0, -rollSpeed));
        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Mouse X") < 0)
        {
            this.transform.Rotate(new Vector3(0, 0, rollSpeed));
        }
        
        //Control Pitch
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Mouse Y") > 0)
        {
            this.transform.Rotate(new Vector3(pitchSpeed, 0, 0));
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Mouse Y") < 0)
        {
            this.transform.Rotate(new Vector3(-pitchSpeed, 0, 0));
        }
    }
	
	
    // Update is called once per frame
	void FixedUpdate () {
        /*
        //engine, throttle, constant force from jet
        rigid.AddForce(transform.forward * speed);
        print(transform.forward*speed);

        //Lift Force
        //lift = Vector3.Project(rigid.velocity, transform.forward);
        //rigid.AddForce(transform.up * lift.magnitude * liftBooster);


        //Banking controls, turning turning left and right on Z axis
        rigid.AddTorque(Input.GetAxis("Horizontal") * transform.forward * -1f);

        //Pitch controls, turning the nose up and down
        rigid.AddTorque(Input.GetAxis("Vertical") * transform.right);

        //Set drag and angular drag according relative to speed
        //rigid.drag = 0.001f * rigid.velocity.magnitude;
        //rigid.angularDrag = 0.01f * rigid.velocity.magnitude;

        */
    }

    void checkSpeed()
    {
        //Control Speed
        if (speed < speedMin)
        {
            speed = speedMin;
        }
        else if (speed >= speedMax)
        {
            speed = speedMax;
        }
    }
}
