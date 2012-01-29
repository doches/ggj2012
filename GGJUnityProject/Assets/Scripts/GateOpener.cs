using UnityEngine;
using System.Collections;

public class GateOpener : MonoBehaviour {
	public GameObject leftGate;
	public GameObject rightGate;

	private bool animating = false;
	private bool opening = false;
	private float openAmount = 0.0f;
	private float openingSpeed = 0.5f;
	private float openDistance = -1.8f;
	private float sidewaysDistance = 1.0f;

	private Vector3 leftGateClosedPosition;
	private Vector3 rightGateClosedPosition;

	void Start () {
	 	leftGateClosedPosition = leftGate.transform.position;
	 	rightGateClosedPosition = rightGate.transform.position;
		leftGate.renderer.sharedMaterial.SetColor("_Color", new Color(1, 1, 1, 1.0f));
	}
	
	void Update () {
		if (animating) {
			if (opening) {
				openAmount += openingSpeed * Time.deltaTime;
			} else {
				openAmount -= openingSpeed * Time.deltaTime;
			}
			if (openAmount >= 1.0f) {
				openAmount = 1.0f;
				animating = false;
			} else if (openAmount <= 0.0f) {
				openAmount = 0.0f;
				animating = false;
			}

			leftGate.renderer.sharedMaterial.SetColor("_Color", new Color(1, 1, 1, 1.0f - openAmount));
			
			// leftGate.transform.position = new Vector3(
			// 	leftGateClosedPosition.x + openAmount * openDistance,
			// 	leftGate.transform.position.y,
			// 	leftGateClosedPosition.z - openAmount * sidewaysDistance
			// );
			// rightGate.transform.position = new Vector3(
			// 	rightGateClosedPosition.x + openAmount * openDistance,
			// 	rightGate.transform.position.y,
			// 	rightGateClosedPosition.z + openAmount * sidewaysDistance
			// );
		}
	}
	
	public void openGates() {
		animating = true;
		opening = true;
	}
	
	public void closeGates() {
		animating = true;
		opening = false;
	}
}
