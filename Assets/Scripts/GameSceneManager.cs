using Cinemachine;
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
        currentScene = SceneManager.GetActiveScene().name;
    }

    [SerializeField] ScreenTint screenTint;
    [SerializeField] CameraConfiner cameraConfiner;
    string currentScene;
    AsyncOperation unload;
    AsyncOperation load;

    public void InitSwitchScene(string to, Vector3 targetPosition)
    {
        StartCoroutine(Transition(to, targetPosition));
    }
    IEnumerator Transition(string to, Vector3 targetPosition)
    {
        screenTint.Tint();
        yield return new WaitForSeconds(1f / screenTint.speed + 0.1f);
        SwitchScene(to, targetPosition);
        while(load != null & unload != null) {
            if (load.isDone) { load = null; }
            if (unload.isDone) { unload = null; }
        yield return new WaitForSeconds(0.1f);}
        yield return new WaitForEndOfFrame();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentScene));
        cameraConfiner.UpdateBounds();
        screenTint.unTint();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void SwitchScene(string to, Vector3 targetPosition) { 
        load = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
       unload =  SceneManager.UnloadSceneAsync(currentScene);
        currentScene = to;
        Transform playerTransform = GameManager.instance.player.transform;
        CinemachineBrain currenctCamera = Camera.main.GetComponent<CinemachineBrain>();
        currenctCamera.ActiveVirtualCamera.OnTargetObjectWarped(playerTransform,
targetPosition - playerTransform.position);
        GameManager.instance.player.transform.position = new Vector3(targetPosition.x, targetPosition.y, playerTransform.position.z);
    }
}
