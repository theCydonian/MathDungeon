using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProj : MonoBehaviour
{
    public GameObject projectile;
    public PlayerControl ctrl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fire () {
        GameObject p1 = Instantiate(projectile);
        p1.GetComponent<MoveProjectiles>().dir = -1;
        GameObject p2 = Instantiate(projectile);
        p2.GetComponent<MoveProjectiles>().dir = 1;
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Mark");
        foreach (GameObject m in markers) {
            Destroy(m);
        }
        Destroy(ctrl);
    }
}
