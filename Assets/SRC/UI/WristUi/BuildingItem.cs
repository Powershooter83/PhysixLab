using UltimateXR.Avatar;
using UltimateXR.Core.Components.Composite;
using UltimateXR.Guides;
using UltimateXR.Locomotion;
using UltimateXR.Manipulation;
using UnityEngine;

public class BuildingItem : UxrGrabbableObjectComponent<BuildingItem>
{
    [SerializeField] private Vector3 scaleAfterPlacing;
    [SerializeField] private Vector3 rotation;
    private Test test;

    private GameObject spawnedObject;

    
    protected override void OnObjectGrabbing(UxrManipulationEventArgs e)
    {
        var o = gameObject;
        InstantiateObject(o.transform.localScale);
        o.transform.parent = null;
        o.tag = "spawned_building";

        var playerPosition = UxrAvatar.LocalAvatar.gameObject.transform.position;
        var cameraForward = UxrAvatar.LocalAvatar.CameraForward.normalized;
        float distanceToMove = 2f;

        Vector3 newPosition = playerPosition + cameraForward * distanceToMove;

        Vector3 updatedNew = new Vector3(newPosition.x, newPosition.y + 2f, newPosition.z);
        
        
        spawnedObject = Instantiate(gameObject, updatedNew, Quaternion.identity);
        spawnedObject.gameObject.name = spawnedObject.gameObject.name.Replace("(Clone)", "");

        spawnedObject.transform.localScale = scaleAfterPlacing;
        spawnedObject.transform.eulerAngles = rotation;
        UxrCompass.Instance.SetTarget(spawnedObject.transform, UxrCompassDisplayMode.Location);
        test = spawnedObject.AddComponent<Test>();
        
        spawnedObject.GetComponent<Rigidbody>().isKinematic = false;

        var buildingItemScript = spawnedObject.GetComponent<BuildingItem>();
        var uxrGrabbableObject = spawnedObject.GetComponent<UxrGrabbableObject>();
        Destroy(buildingItemScript);
        Destroy(uxrGrabbableObject);

        var uxrTeleportLocomotions = FindObjectsOfType<UxrTeleportLocomotion>();
        foreach (var script in uxrTeleportLocomotions)
        {
            script.enabled = false;
        }
    }


    private void InstantiateObject(Vector3 scale)
    {
        var createdObj = Instantiate(gameObject, gameObject.transform.parent, true);
        createdObj.transform.localScale = scale;
        var transform1 = transform;
        createdObj.transform.position = transform1.position;
        createdObj.transform.rotation = transform1.rotation;
        createdObj.gameObject.name = createdObj.gameObject.name.Replace("(Clone)", "");
    }

    protected override void OnObjectReleased(UxrManipulationEventArgs e)
    {
        Destroy(e.GrabbableObject.gameObject);
        Destroy(test);
        UxrCompass.Instance.SetTarget(null);
        spawnedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        var uxrTeleportLocomotions = FindObjectsOfType<UxrTeleportLocomotion>();
        foreach (var script in uxrTeleportLocomotions)
        {
            script.enabled = true;
        }
    }
}