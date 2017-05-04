using UnityEngine;
using System.Collections;

public class MagicOrb : MonoBehaviour
{
	public int hitpoint = 10;
	public float speed = 5.0f;
	public AudioClip audioHit = null;
	public AudioClip audioShoot = null;
	public ParticleSystem particle = null;

	private bool canMove = true;


	void Awake ()
	{
		this.GetComponent<AudioSource>().PlayOneShot (audioShoot);
	}

	void Update ()
	{
		MoveObject ();
	}

	void MoveObject ()
	{
		if ( canMove )
		{
			this.transform.Translate (speed * Time.deltaTime, 0, 0);
		}
	}

	void OnTriggerEnter ( Collider other )
	{
		this.GetComponent<AudioSource>().PlayOneShot (audioHit);

		this.GetComponent<Renderer>().enabled = false;
		this.GetComponent<Collider>().enabled = false;

		canMove = false;

		particle.enableEmission = false;

		Destroy (this.gameObject, audioHit.length);
	}
}
















