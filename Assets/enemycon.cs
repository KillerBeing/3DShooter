using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemycon : MonoBehaviour
{
    private NavMeshAgent enemynv;
    public GameObject player,enemy;
    public ParticleSystem Deathparticles;
    public GameObject[] spawns;
    
    public Text endlesstext,score;
    
    public bool run = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(run == true&&!player.GetComponent<controller>().meDead)
        enemynv.SetDestination(player.transform.position);
    }

	private void Awake()
	{
        enemynv = GetComponent<NavMeshAgent>();
	}
	private void OnDestroy()
	{
        Instantiate(Deathparticles, transform.position, Quaternion.identity);   
        player.GetComponent<controller>().Score++;
        score.text = player.GetComponent<controller>().Score.ToString();
        endlesstext.GetComponent<Animator>().enabled = true;
        
    }

    public void spawn()
	{
        Instantiate(enemy, spawns[Random.Range(0, spawns.Length)].transform.position, transform.rotation);
    }
}
