using UnityEngine;
using System.Collections;

public class BossPart : MonoBehaviour {
	public Texture2D strongTexture;
	public Texture2D weakTexture;
	public Texture2D brokenTexture;
	public GameObject weakPoint;

	private bool isWeak;
	private bool isBroken;
	
	public bool IsBroken() { return isBroken; }

	// Use this for initialization
	void Start () {
		((BossPartWeakPoint)weakPoint.GetComponent("BossPartWeakPoint")).SetPartComponent(this);
		// SetStrong()
		SetWeak();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetWeak() {
		renderer.material.mainTexture = weakTexture;
		collider.enabled = true;
		weakPoint.collider.enabled = true;
	}

	public void SetStrong() {
		renderer.material.mainTexture = strongTexture;
		collider.enabled = true;
		weakPoint.collider.enabled = false;
	}

	public void SetBroken() {
		renderer.material.mainTexture = brokenTexture;
		collider.enabled = false;
		weakPoint.collider.enabled = false;
	}
	
	public void OnTriggerEnter(Collider other) {
		// Something hit the armoured hitbox

		// FIXME: check for bullets, and animate them splashing harmlessly.
		// FIXME: check for enemies and animate them exploding (not harmlessly!).
		// FIXME: check for player and kill them appropriately.
		print("Hit boss armour");
		Destroy(other.gameObject);
	}

	public void OnWeakPointTriggerEnter(Collider other) {
		// Something hit the weak point hitbox
		print("Hit weak point");
		Destroy(other.gameObject);
		SetBroken();
	}
}
