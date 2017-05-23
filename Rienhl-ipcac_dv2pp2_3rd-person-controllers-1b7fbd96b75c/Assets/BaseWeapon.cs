using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour 
{
	public float damage = 2f;
	public float fireRate = 1f;
	public ParticleSystem ps;

	private bool canFire = true;

	void Awake()
	{
		ps = GetComponentInChildren<ParticleSystem>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Fire();
		}
	}

	void Fire()
	{
		if (!canFire)
			return;

		ps.Play();
		canFire = false;
		Invoke("Reload", 1f/fireRate);

		Ray ray = new Ray(this.transform.position, this.transform.forward);
		RaycastHit rayCastHit;

		Physics.Raycast(ray.origin, ray.direction, out rayCastHit, 10f);
		if (rayCastHit.collider == null)
			return;
		DamagableEntity target = rayCastHit.collider.gameObject.GetComponent<DamagableEntity>();
		if (target == null)
			return;
		Debug.Log("HIT ENTITY!");
		target.TakeDamage(damage);
	}

	void Reload()
	{
		canFire = true;
	}
}
