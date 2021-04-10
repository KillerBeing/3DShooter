using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trigger : MonoBehaviour
{
    public GameObject enemy;
    public Text endlesstext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
            enemy.GetComponent<enemycon>().run = true;
            
            
		}
	}
	private void OnTriggerExit(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
