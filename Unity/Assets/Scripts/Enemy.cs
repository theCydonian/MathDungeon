using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject head;
    public GameObject body;

    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Die();
        }
    }

    void Die()
    {
        head.SetActive(true);
        body.SetActive(true);

        Rigidbody h_rigid = head.GetComponent<Rigidbody>();
        Rigidbody b_rigid = body.GetComponent<Rigidbody>();

        Vector3 force = new Vector3(0, 3, 1);
        Vector3 force_2 = new Vector3(4, 2, 3);

        h_rigid.AddTorque(force_2 * Random.Range(-10, 2), ForceMode.Impulse);
        h_rigid.AddForce(force * Random.Range(-10, 2), ForceMode.Impulse);

        b_rigid.AddTorque(force_2 * Random.Range(-10, 2), ForceMode.Impulse);
        b_rigid.AddForce(force * Random.Range(-10, 2), ForceMode.Impulse);

        Destroy(gameObject);
    }

}