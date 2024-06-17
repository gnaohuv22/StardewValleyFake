using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfiner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Cinemachine.CinemachineConfiner confiner;
    void Start()
    {
        UpdateBounds();
    }

    // Update is called once per frame
    public void UpdateBounds()
    {
        GameObject go = GameObject.Find("CameraConfiner");
        if(go == null)
        {
            confiner.m_BoundingShape2D = null;
            return;
        }
        Collider2D bounds = go.GetComponent<Collider2D>();
        confiner.m_BoundingShape2D = bounds;
    }
}
