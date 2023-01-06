using UnityEngine;
using SystemCollections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehavior
{
	[SerializeField] private GameObject loadingScreen;
	[SerializeField] private Slider loadingBar;
	
	public void loadScene(string sceneName) 
	{
		
	}
	
	IEnumerator LoadSceneAsync(string name) 
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(name);
		
		loadingScreen.SetActive(true);
		
		while (!operation.isDone) 
		{
			loadingBar.value = operation.progress;
			
			yield return null;
		}
	}
}