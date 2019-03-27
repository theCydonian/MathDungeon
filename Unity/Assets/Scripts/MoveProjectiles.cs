using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectiles : MonoBehaviour {
	// Use this for initialization
	private FunctionControl fx;
	public int dir; // 1 = right; -1 = left;
	public double amount;
    private float time;
    private PlayerControl pc;

	void Start () {
		fx = GameObject.FindGameObjectWithTag ("Player").GetComponent<FunctionControl> ();
        time = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.localPosition = new Vector3(transform.localPosition.x + (dir * (float)amount), transform.localPosition.y, (float)fx.output(transform.localPosition.x + (dir * amount)));

    }
}
