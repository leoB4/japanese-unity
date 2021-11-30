using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerZone : MonoBehaviour
{
    public bool UnloadScene = false;
    public string Scene;
    [SerializeField] private bool isLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        StartCoroutine(ToDoScene());
    }

    private IEnumerator ToDoScene()
    {
        if (isLoaded) yield break;

        if (UnloadScene)
        {
            AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(Scene);
            isLoaded = true;

            Debug.Log($"{Scene} scene loaded!");
        } else {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);
            isLoaded = true;

            Debug.Log($"{Scene} scene UN-loaded!");
        }

        yield return null;
    }
}
