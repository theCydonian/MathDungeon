using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectiles : MonoBehaviour {
	// Use this for initialization
	private FunctionControl fx;
	public int dir; // 1 = right; -1 = left;
	public double amount;
    private float time;
    public GameObject boom;
    private Rigidbody rb;
    public Vector3 initPos;

	void Start () {
		fx = GameObject.FindGameObjectWithTag ("Player").GetComponent<FunctionControl> ();
        time = 0;
        rb = gameObject.GetComponent<Rigidbody>();
        initPos = rb.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.position = new Vector3((float)(rb.position.x + (dir * amount)),
                 rb.position.y, (float)(initPos.z + fx.output((dir * amount) + rb.position.z - initPos.z)));
    }
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Wall") {
            GameObject temp = Instantiate (boom);
            temp.transform.parent = null;
            temp.transform.position = transform.position;
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Die();
            //GameObject temp = Instantiate(boom);
            //temp.transform.parent = null;
            //temp.transform.position = transform.position;
        }
    }
}
