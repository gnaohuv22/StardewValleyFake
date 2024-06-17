using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TransitionType
{
    Warp,
    Scene
}
public class Transition : MonoBehaviour
{
    [SerializeField] TransitionType transitionType;
    [SerializeField] string sceneNameToTransition;
    [SerializeField] Vector3 targetPosition;

    Transform destination;

    void Start()
    {
        destination = transform.GetChild(1);
    }
    internal void InitiateTransition(Transform toTransition)
    {
        Cinemachine.CinemachineBrain currenctCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();
        switch (transitionType)
        {
            case TransitionType.Warp:
                currenctCamera.ActiveVirtualCamera.OnTargetObjectWarped(toTransition,
                    destination.position - toTransition.position);
                toTransition.position = new Vector3(
            destination.position.x,
            destination.position.y,
            toTransition.position.z);
                break;
            case TransitionType.Scene:
                currenctCamera.ActiveVirtualCamera.OnTargetObjectWarped(toTransition,
    targetPosition - toTransition.position);
                GameSceneManager.instance.SwitchScene(sceneNameToTransition, targetPosition);
                break;
        }

    }

}
