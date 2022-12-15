using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFrame : MonoBehaviour
{
    private FrameTracking fm;
    [SerializeField] private List<GameObject> object3dToPlace;
    private GameObject spawn;

    private void Start()
    {
        fm = GameObject.Find("AR Session Origin").GetComponent<FrameTracking>();
    }
    public void InstantObject(int indexBT)
    {
        Debug.Log("Index " + indexBT);
        if (spawn) 
        {
            Destroy(spawn);
            spawn = Instantiate(object3dToPlace[indexBT], fm.positionObject, object3dToPlace[indexBT].transform.rotation);
        }
        else 
            spawn = Instantiate(object3dToPlace[indexBT], fm.positionObject, object3dToPlace[indexBT].transform.rotation);
    }
}
