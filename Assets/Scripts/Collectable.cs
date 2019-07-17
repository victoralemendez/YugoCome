using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    
    public int collectableAmm = 0;
    public float velocity;
    private AudioSource audiosource;


	private void Start()
	{
        audiosource = GetComponent<AudioSource>();
        
    }


	// Update is called once per frame
	void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * velocity, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            audiosource.Play();
            Debug.Log("Coin *******");
            GameManager.Instance.GetCollectable(collectableAmm);

            //Reproducir sonido

            
			Destroy(gameObject);
        }
    }
}
