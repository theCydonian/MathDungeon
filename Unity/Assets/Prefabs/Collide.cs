using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    public GameObject boom;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            GameObject temp = Instantiate(boom);
            temp.transform.parent = null;
            temp.transform.position = transform.position;
            Destroy(transform.parent.gameObject);
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
