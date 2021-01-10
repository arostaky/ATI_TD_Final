using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   	public Button yourButton;
	AudioSource audio;
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		audio = GetComponent<AudioSource>();    
	}

	void TaskOnClick(){
		 audio.Play(0);
		 StartCoroutine(ExampleCoroutine());
		 
	}
	IEnumerator ExampleCoroutine(){
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
		SceneManager.LoadScene("level1");
    }
}
