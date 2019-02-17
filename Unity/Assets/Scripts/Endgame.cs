using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{

    public Text text;
    public Rigidbody player;
    public GameObject wall1, wall2;
    public Vector3 target1, target2;
    // Start is called before the first frame update
    public bool moveWalls = false;
    public Color finalC;
    void Start()
    {
            finalC = text.color;
            text.gameObject.SetActive(false);
        text.color = Color.clear;
        StartCoroutine(closeWall());
    }

    float t = 0;
    // Update is called once per frame
    void Update()
    {
        if (!moveWalls && player) { 
            player.velocity = -Vector3.left * 2;
        }
        else if (moveWalls && wall1 && wall2)
        {
            t += Time.deltaTime;
            wall1.transform.position = Vector3.MoveTowards(wall1.transform.position, target1, 0.1f);
            wall2.transform.position = Vector3.MoveTowards(wall2.transform.position, target2, 0.1f);
            text.gameObject.SetActive(true);
            text.color = Color.Lerp(Color.clear, finalC, t);
        }
    }

    IEnumerator closeWall()
    {
        yield return new WaitForSeconds(2f);
        moveWalls = true;
    }
}
