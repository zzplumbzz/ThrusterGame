using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
   
    public GameObject Flame1;
    public GameObject Flame2;
    public GameObject Flame3;
    public GameObject Gun;
    public GameObject gunBarrel;
    public GameObject lazer;
    public float lazerSpeed = 100.0f;
    public float lazerLifeTime = 1.0f;
    public float thrust = 50.0f;
    public Rigidbody rb;
    public float playerSpeed = 25.0f;
    public float maxPlayerSpeed = 25.0f;
    private Vector3 moveDirection = Vector3.zero;
    
    public float money;
    public TMP_Text moneyTXT;
    public float lives = 3.0f;
    
    public TMP_Text livesTXT;

    public Transform currentCheckpoint;
   
    public bool isThrusting;
    
    public PauseMenuScript PMS;
    public PlayerPrefs floatToLoad;

    //XboxOneController controls;

    void Awake()
    {
        if(lives <= 0f)
        {
            lives = 3f;
        }
        
        //controls = new XboxOneController();
    }
  

    // Start is called before the first frame update
    void Start()
    {
        Gun.SetActive(false);
        Gun.GetComponent<MeshRenderer>().enabled = false;
        isThrusting = false;
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        livesTXT.SetText(lives.ToString());
        moneyTXT.SetText(money.ToString());
       

        if (Input.GetButton("Jump"))
        {
            isThrusting = true;
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            rb.AddForce(transform.up * thrust);

            if(isThrusting == true)
            {
                //isGrounded = false;
            }
        }
        else
        {
            isThrusting = false;
            
        }

        // if(Input.GetKey(KeyCode.D))
        //     {
        //         rb.transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
                
        //     }
        //     if(Input.GetKey(KeyCode.A))
        //     {
                
        //         rb.transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
        //     }

        // Calculate how fast the player is moving
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"),0 ,0);
        targetVelocity = rb.transform.TransformDirection(targetVelocity);
        targetVelocity *= playerSpeed;

        // // Apply a force that attempts to reach target velocity
        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxPlayerSpeed, maxPlayerSpeed);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxPlayerSpeed, maxPlayerSpeed);//ORIGINAL
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        // float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        // //transform.rotation = Quaternion.LookRotation(movement);//Quaternion.LookRotation
        // transform.Translate (movement * playerSpeed * Time.deltaTime, Space.World);
        
    }

    public void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            PMS.pauseMenuCanvas.SetActive(true);
        }

        

        if (isThrusting == false)
        {
            Flame1.SetActive(false);
            Flame2.SetActive(false);
            Flame3.SetActive(false);
        }
        else if (isThrusting == true)
        {
            Flame1.SetActive(true);
            Flame2.SetActive(true);
            Flame3.SetActive(true);
        }

        if(Gun.GetComponent<MeshRenderer>().enabled == true && Input.GetKeyDown(KeyCode.N))
        {
            GameObject lazerClone = Instantiate(lazer, gunBarrel.transform.position, Quaternion.identity) as GameObject;
            Rigidbody lazerPrefabRigidBody = lazerClone.GetComponent<Rigidbody>();
            lazerPrefabRigidBody.AddForce(Vector3.right * lazerSpeed, ForceMode.Impulse);
            if(Time.deltaTime >= 3)
            {
            Destroy(lazer);
            Destroy(lazerClone);
            }
        }

        
    }

  

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathPlane"))
        {
            
            lives -= 1f;

            if (lives <= 0f)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (other.CompareTag("Flame"))
        {
            
            lives -= 1f;

            if (lives <= 0f)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (other.CompareTag("1UP"))
        {
            lives += 1f;
            Destroy(other.gameObject);
            
        }

        if (other.CompareTag("Money"))
        {
            money += 10f;
            Destroy(other.gameObject);

            if(money == 100f)
            {
                lives += 1;
            }
            if(money == 200f)
            {
                lives += 1;
            }
            if(money == 300f)
            {
                lives += 1;
            }
            if(money == 400f)
            {
                lives += 1;
            }
            if(money == 500f)
            {
                lives += 1;
            }
        }

        if(other.CompareTag("SpeedUp"))
        {
            playerSpeed = 50;
            maxPlayerSpeed = 50;
        }
        
        if(other.CompareTag("SpeedDown"))
        {
            playerSpeed = 10;
            maxPlayerSpeed = 10;
        }

        if(other.CompareTag("GravityUp"))
        {
            rb.mass = 6;
            thrust = 80;
        }

        if(other.CompareTag("GravityDown"))
        {
            rb.mass = 0.5f;
            thrust = 30;
        }

        if (other.CompareTag("Gun"))
        {
            Gun.SetActive(true);
            Gun.GetComponent<MeshRenderer>().enabled = true;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("SpeedUp"))
        {
            playerSpeed = 25;
            maxPlayerSpeed = 25;
        }

        if(other.CompareTag("SpeedDown"))
        {
            playerSpeed = 25;
            maxPlayerSpeed = 25;
        }

        if(other.CompareTag("GravityUp"))
        {
            rb.mass = 1;
            thrust = 50;
        }

        if(other.CompareTag("GravityDown"))
        {
            rb.mass = 1;
            thrust = 50;
        }
    }

    void OnCollision()
    {

    }

    // public void SaveGame()
    // {
    //     PlayerPrefs.SetFloat("money", money);
    //     PlayerPrefs.SetFloat("lives", lives);
    //     PlayerPrefs.Save();
    //     Debug.Log("Game data saved!");
    // }

    // public void LoadGame()
    // {
	
	// 	money = PlayerPrefs.GetFloat("money");
	// 	lives = PlayerPrefs.GetFloat("lives");
	// 	Debug.Log("Game data loaded!");

   
    // }
}
