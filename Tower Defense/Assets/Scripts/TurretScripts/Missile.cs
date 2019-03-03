using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	private Transform target;


	public float missileDamage;
	public float speed;
	public float explosionRadius;

	public GameObject impactEffect;

	public void Seek(Transform _target)
	{

		target= _target;

	}

	void Update()
	{

		if(target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 distanceFromEnemy = target.position - transform.position;

		float speedThisFrame = speed * Time.deltaTime;

		if(distanceFromEnemy.magnitude <= speedThisFrame)
		{
			
			MissileHitTarget();
			return;
		}

		transform.Translate(distanceFromEnemy.normalized * speedThisFrame,Space.World );
		transform.LookAt(target);

	}


	public void MissileHitTarget()
	{
		
		GameObject effectinstance = (GameObject) Instantiate(impactEffect,transform.position,transform.rotation);

		Destroy(effectinstance,5f);
		Explode();
		Destroy(gameObject);
	
	}

	public void Explode ()
	{
		Collider [] colliders  = Physics.OverlapSphere(transform.position,explosionRadius);

		foreach (Collider collider in colliders)
		{
			if(collider.tag == "Enemy")
				{
					Damage(collider.transform); 

				}

		}

	}

	public void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if(e != null)
			e.TakeDamage(missileDamage*Player.instance.skillTreeVariables.missileDamMult);

		Debug.Log("Füze hasarı : " + missileDamage*Player.instance.skillTreeVariables.missileDamMult );
	}

}
