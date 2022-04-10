using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    public float thrust = 40f;
    public Rigidbody rb;
    public float playerSpeed = 25;
    public float maxPlayerSpeed = 50.0f;
    private Vector3 moveDirection = Vector3.zero;
    
    public static float money;
    public TMP_Text moneyTXT;
    public static float lives = 3f;
    
    public TMP_Text livesTXT;

   
    public bool isThrusting;

    void Awake()
    {
        if(lives <= 0f)
        {
            lives = 3f;
        }
        //DontDestroyOnLoad(lives);
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
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathPlane"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            
        }
    }

   
}
