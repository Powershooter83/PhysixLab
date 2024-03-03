using System.Collections.Generic;
using UltimateXR.Core.Components.Composite;
using UltimateXR.Manipulation;
using UnityEngine;

public class PathVisualizer : UxrGrabbableObjectComponent<PathVisualizer>
{
    private LineRenderer _lineRenderer;
    private List<Vector3> points = new();
    private UxrGrabbableObject _grabbableObject;
    private bool _itemIsInventory = true;

    private void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
        _grabbableObject = gameObject.GetComponent<UxrGrabbableObject>();
    }

    protected override void OnObjectReleased(UxrManipulationEventArgs e)
    {
        points.Clear();
        if (ManipulationTab._showTracing)
        {
            points.Add(transform.position);
        }
    }

    private void Update()
    {
        if (_grabbableObject.IsBeingGrabbed || _itemIsInventory)
        {
            return;
        }

        if (!ManipulationTab._showTracing) return;
        points.Add(transform.position);
        _lineRenderer.positionCount = points.Count;
        _lineRenderer.SetPositions(points.ToArray());
    }

    public void setitemIsInventory()
    {
        _itemIsInventory = false;
    }
    
    public void ClearPoints()
    {
        points.Clear();
        _lineRenderer.positionCount = 0;
    }
    
}