using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FireDamage : MonoBehaviour
{
    public string hp = "100";
    public AudioSource audioSRC;
    public Text health;
    // Start is called before the first frame update
    void Start()
    {
        Counter.health = 100;
        health.text = hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Fire")
        {
            audioSRC.Play();
            Counter.health -= 20;
            health.text = (Counter.health).ToString();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
