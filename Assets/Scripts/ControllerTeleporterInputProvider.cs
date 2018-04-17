using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ControllerTeleporterInputProvider : MonoBehaviour {
	public VRInput VR_Input;
	public VREyeRaycaster VR_EyeRaycaster;
	public SteamVR_Teleporter theTeleporterComponent;
	private ClickedEventArgs theArgs;
	private bool isTeleporting;
	public int teleportSafeLayer;
	public float totalTeleportTime = 1;
	void Start () {
		// grab a reference to the SteamVR teleporter Component
		if (theTeleporterComponent==null)
		{
			if(GetComponent<SteamVR_Teleporter>())
			{
				theTeleporterComponent = GetComponent<SteamVR_Teleporter>();
			}
		}
	}
	void OnClick()
	{
		// make sure that we are not already teleporting
		if (isTeleporting)
			return;
		if ((VR_EyeRaycaster.isHit) &&
			(VR_EyeRaycaster.hitLayer == teleportSafeLayer)) {
			// call the function to handle the actual fade
			OnTriggerClicked ();
		}
	}
	// this function will call the teleporter and pretend to be a controller
	// click
	public virtual void OnTriggerClicked()
	{
		// start a nice fullscren / full headset fade out effect
		SteamVR_Fade.Start(Color.black, totalTeleportTime /2);

		// we set isTeleporting so that the teleporter is locked during the fade
		// out
		isTeleporting = true;
		// the actual teleport will happen in 0.5 seconds, at the same time the
		// fade out reaches full darkness
		Invoke("DoTeleport", totalTeleportTime /2);
	}

	void DoTeleport()
	{
		// start a nice fade in effect
		SteamVR_Fade.Start(Color.clear, totalTeleportTime /2);
		// done with the teleport, so we can allow the user to teleport again
		// now if they want
		isTeleporting = false;
		// tell SteamVR to take care of the actual teleport move now
		theTeleporterComponent.DoClick(this, theArgs);
	}
	private void OnEnable()
	{
		// when this script is first enabled in the scene,
		// subscribe to events from vrInput
		VR_Input.OnClick += OnClick;
	}
	private void OnDisable()
	{
		// unsubscribe from events from vrInput
		VR_Input.OnClick -= OnClick;
	}
}