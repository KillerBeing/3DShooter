using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void Awake()
	{
        Destroy(this.gameObject, lifespan);
	}

	private void OnCollisionEnter(Collision collision)
	{
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "enemy")
		{
            collision.gameObject.GetComponent<enemycon>().spawn();
            Destroy(collision.gameObject);
		}
        Destroy(this.gameObject);
	}


}
