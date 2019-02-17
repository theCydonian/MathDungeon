using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectiles : MonoBehaviour {
	// Use this for initialization
	private FunctionControl fx;
	public int dir; // 1 = right; -1 = left;
	public double amount;
	void Start () {
		fx = GameObject.FindGameObjectWithTag ("Player").GetComponent<FunctionControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3((float)fx.output(dir*amount + transform.position.z), transform.position.y, (float)(transform.position.z + dir * amount));
	}
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Wall") {
			print ("hello");
		}
	}
}
