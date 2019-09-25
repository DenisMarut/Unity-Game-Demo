using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager1 : MonoBehaviour
{
    public Canvas c1, c2, c3;
    public Text coins, health;
    
    // Start is called before the first frame update
    void Start()
    {
        c1 = c1.GetComponent<Canvas>();
        c2 = c2.GetComponent<Canvas>();
        c1.enabled = false;
        c2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter.health==0)
        {
            c1.enabled = true;
        }
        if(Counter.health==0 && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
        if(Counter.health==0 && Input.GetKeyDown(KeyCode.F1))
        {
            Application.Quit();
        }
        if(Counter.coinCounter >= 5)
        {
            c2.enabled = true;
        }
        if(Counter.coinCounter >= 5 && Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(2);
        }

        
       
    }

    
}
