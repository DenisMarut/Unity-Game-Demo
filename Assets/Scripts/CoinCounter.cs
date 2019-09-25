using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public string coi = "0";
    public AudioSource audioSrc;
    private  AudioClip coinSound;
    public Text coinDisplay;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Coin")
        {
            Counter.coinCounter += 1;
            audioSrc.Play();
            Destroy(other.gameObject);
            coinDisplay.text = (Counter.coinCounter).ToString();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        coinDisplay.text = coi;
        Counter.coinCounter = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter.coinCounter >=6 && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(2); 
        }
    }
}
