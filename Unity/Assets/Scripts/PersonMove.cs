using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonMove : MonoBehaviour
{
    public GameObject person;
    public Text mainText;
    public Button retryButton;
    private int i = 0;
    private int j = 0;
    // Start is called before the first frame update
    void Start()
    {
      mainText.text = "";
      retryButton.gameObject.SetActive(false);
      retryButton.onClick.AddListener(Retry);
    }

    // Update is called once per frame
    void Update()
    {
      if (i < 12) {
        person.transform.Rotate(Vector3.forward * (20 - i));
        i += 1;
      } else {
        mainText.text = "The doors have closed.  Try again to reopen them.";
        retryButton.gameObject.SetActive(true);
      }
    }

    void Retry() {
      // add Retry functionality
    }
}
