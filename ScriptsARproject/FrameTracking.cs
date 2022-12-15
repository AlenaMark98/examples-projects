using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARTrackedImageManager))]
public class FrameTracking : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits;

    private ARAnchorManager aRAnchorManager;
    private ARPlaneManager aRPlaneManager;
    public Vector3 positionObject;

    private ARTrackedImageManager aRTrackedImageManager;
    private IReferenceImageLibrary refLibrary;

    // tracking reference Image
    [SerializeField] private List<GameObject> ObjectsToPlace;
    private int refImageCount;
    private Dictionary<string, GameObject> allObjects;


    private void Awake()
    {
        aRPlaneManager = GetComponent<ARPlaneManager>();
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        hits = new List<ARRaycastHit>();

        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
        aRPlaneManager.planesChanged += OnArPlanesChanged;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
        aRPlaneManager.planesChanged -= OnArPlanesChanged;
    }

    private void OnArPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // added
        foreach (ARPlane plane in args.added)
        {
            positionObject = plane.center;
            Debug.Log("plane.center " + positionObject);
        }

        // updated
        foreach (ARPlane plane in args.updated)
        {
            aRPlaneManager.enabled = false;
            aRRaycastManager.enabled = false;
        }

        // removed
        foreach (ARPlane plane in args.removed)
        {

        }
    }

    void Start()
    {
        refLibrary = aRTrackedImageManager.referenceLibrary;
        refImageCount = refLibrary.count;
        LoadObjectDictionary();

    }


    void LoadObjectDictionary()
    {
        allObjects = new Dictionary<string, GameObject>();
        for (int i = 0; i < refImageCount; i++)
        {
            GameObject newOverlay = new GameObject();
            newOverlay = ObjectsToPlace[i];
            if (ObjectsToPlace[i].gameObject.scene.rootCount == 0)
            {
                newOverlay = Instantiate(ObjectsToPlace[i], transform.localPosition, Quaternion.identity);
                Debug.Log("transform.localPosition " + transform.localPosition);
            }

            allObjects.Add(refLibrary[i].name, newOverlay);
            newOverlay.SetActive(false);
        }
    }

    void ActivateTrackedObject(string imageName)
    {
        Debug.Log("Tracked the target: " + imageName);
        allObjects[imageName].SetActive(true);
        allObjects[imageName].transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);     
    }

    private void UpdateTrackedObject(ARTrackedImage trackedImage)
    {
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            allObjects[trackedImage.referenceImage.name].SetActive(true);
            allObjects[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
            allObjects[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;
        }
        else
        {
            allObjects[trackedImage.referenceImage.name].SetActive(false);
        }
    }


    void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var addedImage in args.added)
        {
            ActivateTrackedObject(addedImage.referenceImage.name);
        }

        foreach (var updated in args.updated)
        {
            UpdateTrackedObject(updated);
        }

        foreach (var trackedImage in args.removed)
        {
            Destroy(trackedImage.gameObject);
        }
    }


}
