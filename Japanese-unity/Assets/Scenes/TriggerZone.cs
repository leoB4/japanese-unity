using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        StartCoroutine(LoadingMainMenu());
        Debug.Log("collid");
    }

    private IEnumerator LoadingMainMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene2_flowers", LoadSceneMode.Additive);
        // wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
            yield return null;

        Debug.Log("Scene2_flowers scene loaded!");
        // TODO init
        // MainMenu.instance.Initialize();
    }
}
