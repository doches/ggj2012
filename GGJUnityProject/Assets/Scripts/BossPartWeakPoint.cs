using UnityEngine;
using System.Collections;

public class BossPartWeakPoint : MonoBehaviour {
	private BossPart partComponent;

	public void SetPartComponent(BossPart newPartComponent) {
		partComponent = newPartComponent;
	}

	public void OnTriggerEnter(Collider other) {
		partComponent.OnWeakPointTriggerEnter(other);
	}
}
