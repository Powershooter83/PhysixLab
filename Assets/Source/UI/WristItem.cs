using UltimateXR.Manipulation;
using UnityEngine;

public class WristItem : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private UxrGrabbableObject _grabbableObject;

    private bool hasBeenGrapped;

    void Update()
    {
        if (hasBeenGrapped)
        {
            return;
        }

        if (!UxrGrabManager.Instance.IsBeingGrabbed(_grabbableObject)) return;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        rigidbody.isKinematic = false;
        gameObject.transform.parent = null;
        hasBeenGrapped = true;
    }
}