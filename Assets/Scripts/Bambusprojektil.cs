﻿using UnityEngine;
using System.Collections;

public class Bambusprojektil : MonoBehaviour {

	private Vector3 targetposition;
	private int speed = 3;
	float step;

	// Use this for initialization
	void Start () {
		Projektilzerstoerung ();
		step = speed * Time.deltaTime;
		transform.rotation = Quaternion.LookRotation(transform.position - Bambus.target[0].transform.position);
		targetposition = Bambus.target[0].transform.position - transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		transform.position += targetposition * step;

	}
	void OnTriggerEnter(Collider other)
	{
		switch (other.tag) 
		{
		case "Enemy":
			(int)Bambus.target[0].GetComponent<Health>().health -= 20;
			Destroy (transform.gameObject);
			break;
		}
	}

	IEnumerator Projektilzerstoerung()
	{
		while (true) {
			yield return new WaitForSeconds (5);
			Destroy (transform.gameObject);
		}
	}
}
