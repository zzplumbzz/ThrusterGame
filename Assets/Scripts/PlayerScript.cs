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
    public float thrust = 50f;
    public Rigidbody rb;
    public float playerSpeed = 25;
    public float maxPlayerSpeed = 50.0f;
    private Vector3 moveDirection = Vector3.zero;
    
    public static float money;
    public TMP_Text moneyTXT;
    public static float lives = 3f;
    
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

        // Calculate how fast the player is moving
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"),0 ,0);
        targetVelocity = rb.transform.TransformDirection(targetVelocity);
        targetVelocity *= playerSpeed;

        // Apply a force that attempts to reach target velocity
        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxPlayerSpeed, maxPlayerSpeed);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxPlayerSpeed, maxPlayerSpeed);//ORIGINAL
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

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
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("SavedMoney", money);
        PlayerPrefs.SetFloat("SavedLives", lives);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
	
		PlayerPrefs.GetFloat("SavedMoney");
		PlayerPrefs.GetFloat("SavedLives");
		Debug.Log("Game data loaded!");

   
    }
}
