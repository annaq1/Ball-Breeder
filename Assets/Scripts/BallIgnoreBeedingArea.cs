using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIgnoreBeedingArea : MonoBehaviour {

    public Transform collider;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider.GetComponent<Collider2D>());
	}
}
