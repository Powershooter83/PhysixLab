using UltimateXR.Core.Components.Composite;
using UltimateXR.Manipulation;
using UnityEngine;

public class Item : UxrGrabbableObjectComponent<Item>

{
    [SerializeField] private Vector3 scaleAfterPickup;

    private PathVisualizer _pathVisualizer;


    private void Start()
    {
        _pathVisualizer = gameObject.GetComponent<PathVisualizer>();
    }

    protected override void OnObjectGrabbing(UxrManipulationEventArgs e)
    {
        var o = gameObject;
        InstantiateObject(o.transform.localScale);
        o.transform.parent = null;
        o.transform.localScale = scaleAfterPickup;
        o.tag = "spawned";
        _pathVisualizer.setitemIsInventory();
        Destroy(this);
    }


    private void InstantiateObject(Vector3 scale)
    {
        var createdObj = Instantiate(gameObject, gameObject.transform.parent, true);
        createdObj.transform.localScale = scale;
        var transform1 = transform;
        createdObj.transform.position = transform1.position;
        createdObj.transform.rotation = transform1.rotation;
        createdObj.gameObject.name = createdObj.gameObject.name.Replace("(Clone)", "");
        var grabbableObject = createdObj.GetComponent<UxrGrabbableObject>();
        grabbableObject.VerticalReleaseMultiplier = ManipulationTab.releaseMultiplier;
        grabbableObject.HorizontalReleaseMultiplier = ManipulationTab.releaseMultiplier;
    }
}