using UnityEngine;
using VRStandardAssets.Utils;
[RequireComponent(typeof(SteamVR_TrackedObject))]
[RequireComponent(typeof(SphereCollider))]
public class HandClick : MonoBehaviour
{
	public int interactiveLayer = 10;
	public float touchRadius = 0.06f;
	SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device myDevice;
	private GameObject theClosestGO;
	private bool lastTrigger = false;
	void Awake()
	{
		// grab references to things we need..
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		SphereCollider myCollider = GetComponent<SphereCollider>();
		// do a little set up on the sphere collider to set the radius and make
		// sure that it's a trigger
		myCollider.radius = touchRadius;
		myCollider.isTrigger = true;
	}
	void FixedUpdate()
	{
		myDevice = SteamVR_Controller.Input((int)trackedObj.index);
		bool controllerTrigger =
			myDevice.GetTouch(SteamVR_Controller.ButtonMask.Trigger);
		if (!lastTrigger && controllerTrigger)
		{
			DoClick ();
		}
		lastTrigger = controllerTrigger;
	}
	void DoClick()
	{
		if (theClosestGO != null) {
			VRInteractiveItem interactible =
				theClosestGO.GetComponent<VRInteractiveItem> ();
			if (interactible)
				interactible.Click ();
		}
	}
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.layer == interactiveLayer)
		{
			theClosestGO = collision.gameObject;
		}
	}
	void OnTriggerExit(Collider collision)
	{
		theClosestGO = null;
	}
}