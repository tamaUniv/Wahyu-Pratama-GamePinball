using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
	// get variabel bola sebagai referensi untuk pengecekan
	public Collider bola;
    public float multiplier;
	private Animator animator;
	public AudioManager audioManager;
	public VFXManager vfxManager;
	public ScoreManager scoreManager;

	public float score;

	private void Start()
	{
	// get animatornya saat Start
  		animator = GetComponent<Animator>();
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		// memastikan yang menabrak adalah bola
    if (collision.collider == bola)
    {
		// ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
		Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
		audioManager.PlaySFX(collision.transform.position);
		vfxManager.PlayVFX(collision.transform.position);
    	bolaRig.velocity *= multiplier;
		animator.SetTrigger("HitTrigger");
		scoreManager.AddScore(score);
    }
  }
}
