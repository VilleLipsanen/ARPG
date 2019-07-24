using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f;
    float perkele = 2f;
    public GameObject Cam;
    Vector2 input;

    Vector3 forward, right;
    public GameObject Player;

    public float speed = 6f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.
    public GameObject EquippedWeapon;
    [HideInInspector]
    public Vector3 playerToMouse;

    public int healAmount = 10;

    void Awake()
    {


        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        //Turning();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //EquippedWeapon.GetComponent<AxeAttack>().PerformAttack();
        }

        forward = Cam.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Cam.transform.right;
        right.y = 0;
        right = Vector3.Normalize(right);//take forward and right angle from camera

        Quaternion _rotation = transform.rotation;
        _rotation.eulerAngles = new Vector3(_rotation.eulerAngles.x, Cam.transform.rotation.eulerAngles.y, _rotation.eulerAngles.z);
        transform.rotation = _rotation;
    }

    public void gona()
    {
        Debug.Log("gona");
    }



    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Move(float h, float v)
    {

         if (h != 0 || v != 0)
         {
             //anim.SetBool("Run", true);
         }
         else
         {
             //anim.SetBool("Run", false);
         }
        //take input from axixes
        input = new Vector2(h, v);
        //clamp so doesnt go too fast diagonally
        input = Vector2.ClampMagnitude(input, 4);

        //apply correct movement to the character model
        playerRigidbody.transform.position += (forward * input.y + right * input.x) * Time.deltaTime * moveSpeed;
    }

    /* private void OnTriggerEnter(Collider collision)
     {
         PlayerHealth playerHealth = GetComponent<PlayerHealth>();
         if (collision.gameObject.CompareTag("Item"))
         {
             playerHealth.HealthChange(healAmount);
             collision.gameObject.SetActive(false);
         }
     }*/

    private void OnCollisionEnter(Collision other)
    {
        //PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        //if (other.gameObject.CompareTag("Item"))
        {
            //playerHealth.HealthChange(healAmount);
            //other.gameObject.SetActive(false);
        }
    }
}