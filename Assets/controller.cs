using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update

    float speed = 0.1f;
    public GameObject bullets;
    public GameObject muzzle;
    public Camera Camera;
    public bool meDead = false,pause = true, canjump = true;
    public int Score = 0;
    private int Ammo = 20;
    public Text ammo,Highscore;
    public int spawn;
    public static AudioClip sound;
    static AudioSource shot;

    private float pitch = 0.0f, yaw = 0.0f;
    public float speedh = 2.0f, speedv = 2.0f;

	private void Awake()
	{
        GameManager.i.PauseGame += Pause;
        GameManager.i.StartGame += Resume;
        GameManager.i.CallPauseGame();
    }
	void Start()
    {
        //Score = PlayerPrefs.GetInt("FinalScore");
        Highscore.text = PlayerPrefs.GetInt("FinalScore").ToString();
        ammo.text = Ammo.ToString();
        sound = Resources.Load<AudioClip>("gunshot");
        shot = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!GameManager.i.paused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
                Shoot();
            }

            yaw += speedh * Input.GetAxis("Mouse X");
            pitch += speedv * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f);
            Camera.transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f);


            if(Input.GetKey(KeyCode.Space))
			{
                if(transform.position.y <= 2.2 && canjump)
                GetComponent<Rigidbody>().AddForce(0, 5, 0);
			}
        }
    

    }

	private void FixedUpdate()
	{
        if (!GameManager.i.paused)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, speed));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-new Vector3(0, 0, speed));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(speed, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-new Vector3(speed, 0, 0));
            }
        }
        
    }

   

    private void Shoot()
    {
        if (Ammo > 0)
        {
            Ammo -= 1;

            shot.PlayOneShot(sound);

            ammo.text = Ammo.ToString();

            var ray = Camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            var bullet = Instantiate(bullets, muzzle.transform.position, new Quaternion(90, muzzle.transform.rotation.y, muzzle.transform.rotation.z, 0));
            bullet.GetComponent<Rigidbody>().velocity = ray.direction * 100;

        }
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "enemy")
        {
            GetComponent<Rigidbody>().freezeRotation = false;
            meDead = true;
            GetComponent<controller>().enabled = false;

           

            //HighScore

            if (PlayerPrefs.GetInt("FinalScore")<Score)
			{
                PlayerPrefs.SetInt("FinalScore", Score);
            }
            Highscore.text = PlayerPrefs.GetInt("FinalScore").ToString();
        }
        if (collision.gameObject.tag == "Ammo")
		{
            Ammo += 20;
            Destroy(collision.gameObject);
		}
	}


    public void Pause()
    {
       
        
            Time.timeScale = 0;
            GameManager.i.paused = true;
        
    }

    public void Resume()
    {
        
            Time.timeScale = 1;
            GameManager.i.paused = false;
        
    }

	
}
