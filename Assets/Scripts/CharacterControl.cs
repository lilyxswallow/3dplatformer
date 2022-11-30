using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour

{
    public Animator anim;

    Vector3 respawnPoint = new Vector3 (63.144f, 205.72f, 394.48f);
        public float maxSpeed = 12f;
        float rotation = 0.0f;
    float camRotation = 0.0f;
    GameObject cam;
    Rigidbody myRigidbody;

    bool isOnGround;
        public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;

    public bool hasKey = false;

    public AudioClip backgroundMusic;
    public AudioSource musicsource;

    

   void Start()
    {
    
        musicsource.clip = backgroundMusic;
        musicsource.loop = true;
        Cursor.lockState = CursorLockMode.Locked;

        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        anim.SetBool("isOnGround", isOnGround);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jumped");
            myRigidbody.AddForce(transform.up * jumpForce);
        }



        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        anim.SetFloat("speed", newVelocity.magnitude);


        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;

            transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key")
        {
            hasKey = true;

        }
        if((hasKey = true) && (other.tag == "Door"))
        {
            SceneManager.LoadScene(1);
          
        }
        else if (hasKey = false && other.tag == "Door")
        {
        
        }

        if (other.tag == "Death Box")
        {
            transform.position = respawnPoint;
        }

    }

}
      
    
