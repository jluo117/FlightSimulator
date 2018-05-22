using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightContorl : MonoBehaviour {
    private float buttonRotation = 0f;
    private float upDown = 0f;
    public float detalRot;
    public GameObject Plane;
    public GameObject Xwing;
    public float acceleration = 0;
    private Vector3 lastPosition = new Vector3(0, 0, 0);
    private Quaternion lastRotation = new Quaternion(0, 0, 0, 0);
    private string leftKey = "left";
    private string rightKey = "right";
    //private string upKey = "up";
    //private string downKey = "down";
    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 deltaPos = transform.position - lastPosition;
        Quaternion deltaRot = transform.rotation * Quaternion.Inverse(lastRotation);

        bool moveForward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool moveBack = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool dpad_move = false;

        if (OVRInput.Get(OVRInput.Button.DpadUp))
        {
            moveForward = true;
            dpad_move = true;

        }

        if (OVRInput.Get(OVRInput.Button.DpadDown))
        {
            moveBack = true;
            dpad_move = true;
        }
        if (((dpad_move) && (moveForward)) || (Input.GetKey("w")))
        {
            print("up");
            acceleration += (float)0.1;
        }

        if ((dpad_move) && ((moveBack)) || (Input.GetKey("s")))
        {
            print("down");
            acceleration += (float)-0.1;
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * 25 * Time.deltaTime);
            print("left");
            buttonRotation += 10;
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * 25 * Time.deltaTime);
            print("Right");
            buttonRotation += -10;
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(Vector3.up * 25 * Time.deltaTime);
            upDown += 10;
        }
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.down * 25 * Time.deltaTime);
            upDown -= 10;
        }
        //Vector3 planePosition = Plane.transform.position;
        //if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        //{
        //    acceleration += (float)0.1;
        //}
        //if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        //{
        //    acceleration += (float)-0.1;
        //}
       // Plane.transform.Translate(Vector3.forward * acceleration * Time.deltaTime);
        ////Plane.transform.position += deltaPos;
       
        //lastPosition = transform.position;
        //lastRotation = transform.rotation;
        transform.Translate(Vector3.forward * acceleration * Time.deltaTime);
        this.transform.rotation *= deltaRot;

        Vector3 euler = transform.rotation.eulerAngles;
        euler.y += buttonRotation;
        euler.x += upDown;
        transform.rotation = Quaternion.Euler(euler);
        //buttonRotation = 0;
    }
    
}
