using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void RoadMainScene(){
		SceneManager.LoadScene(0);
	}
	public void RoadPlayerScene(){
		SceneManager.LoadScene(1);
	}
	public void RoadLearnedScene(){
		SceneManager.LoadScene(2);
	}
}
