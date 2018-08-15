using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class controllerTracker : MonoBehaviour {

    private objectTracker tracker;
	// Use this for initialization
	void Start ()
    {
        tracker = gameObject.GetComponent<objectTracker>();
	}

    // Update is called once per frame
    void Update()
    {
        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Trigger))
        {
            //left trigger press
            Debug.Log("left trigger press");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.triggerPress));
        }

        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
        {
            //right trigger press
            Debug.Log("right trigger press");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.triggerPress));
        }

        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Grip))
        {
            //left grip press
            Debug.Log("left grip press");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.gripPress));
        }

        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Grip))
        {
            //right grip press
            Debug.Log("right grip press");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.gripPress));
        }

        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Pad))
        {
            //left touchpad press
            Debug.Log("left touchpad press");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.touchpadPress));
        }

        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Pad))
        {
            //right touchpad press
            Debug.Log("right touchpad press");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.touchpadPress));
        }

        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.PadTouch))
        {
            //left touchpad touch
            Debug.Log("left touchpad touch");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.touchpadTouch));
        }

        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.PadTouch))
        {
            //right touchpad touch
            Debug.Log("right touchpad touch");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.touchpadTouch));
        }

        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Menu))
        {
            //left menu press
            Debug.Log("left menu press");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.menuPress));
        }

        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Menu))
        {
            //right menu press
            Debug.Log("right menu press");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.menuPress));
        }

        /* ****************************************************************************** */
        /* ****************************************************************************** */
        /* ****************************************************************************** */
        /* ****************************************************************************** */

        if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Trigger))
        {
            //left trigger press
            Debug.Log("left trigger release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.triggerRelease));
        }

        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Trigger))
        {
            //right trigger press
            Debug.Log("right trigger release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.triggerRelease));
        }

        if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Grip))
        {
            //left grip press
            Debug.Log("left grip release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.gripRelease));
        }

        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Grip))
        {
            //right grip press
            Debug.Log("right grip release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.gripRelease));
        }

        if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Pad))
        {
            //left touchpad press
            Debug.Log("left touchpad release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.touchpadPressRelease));
        }

        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Pad))
        {
            //right touchpad press
            Debug.Log("right touchpad release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.touchpadPressRelease));
        }

        if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.PadTouch))
        {
            //left touchpad touch
            Debug.Log("left touchpad release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.touchpadTouchRelease));
        }

        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.PadTouch))
        {
            //right touchpad touch
            Debug.Log("right touchpad release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.touchpadTouchRelease));
        }

        if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Menu))
        {
            //left menu press
            Debug.Log("left menu release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.left, eventType.menuRelease));
        }

        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Menu))
        {
            //right menu press
            Debug.Log("right menu release");
            tracker.trackedControllerEvents.Add(new trackedControllerEvent(hand.right, eventType.menuRelease));
        }
    }
}
