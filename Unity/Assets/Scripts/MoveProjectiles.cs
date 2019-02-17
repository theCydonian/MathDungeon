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
	void Start () {
		fx = GameObject.FindGameObjectWithTag ("Player").GetComponent<FunctionControl> ();
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
            transform.localPosition = new Vector3((float)fx.output(dir * amount + transform.position.z),
                 transform.position.y, (float)(transform.position.z + dir * amount));
    }
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Wall") {
            GameObject temp = Instantiate (boom);
            temp.transform.parent = null;
            StartCoroutine(kill());
        }
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Die();
            GameObject temp = Instantiate(boom);
            temp.transform.parent = null;
            StartCoroutine(kill());
        }
    }
    IEnumerator kill () {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
