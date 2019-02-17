using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startTimer() {
        StartCoroutine(LoseTime());
    }
    IEnumerator LoseTime () {
        yield return new WaitForSeconds(5);
        foreach(GameObject a in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (a.GetComponent<Enemy>().dead == false)
            {
                SceneManager.LoadScene("End Screen");
            }
        }
    }
}
