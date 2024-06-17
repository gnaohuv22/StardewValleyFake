using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    public void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    string currentScene;

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void SwitchScene(string to, Vector3 targetPosition) { SceneManager.LoadScene(to, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(currentScene);
        currentScene = to;
        Transform playerTransform = GameManager.instance.player.transform;
        GameManager.instance.player.transform.position = new Vector3(targetPosition.x, targetPosition.y, playerTransform.position.z);
    }
}
