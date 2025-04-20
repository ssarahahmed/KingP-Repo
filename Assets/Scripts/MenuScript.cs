using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

     public void gotoGame() {
        StartCoroutine(WaitForSoundTransition("MainGame"));
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    private IEnumerator WaitForSoundTransition(string sceneName){
        AudioSource audioSource = GetComponentInChildren<AudioSource>();
        audioSource.Play(); //Play the Sound
        yield return new WaitForSeconds(audioSource.clip.length); 
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
