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
		if (weakPoint) {
			((BossPartWeakPoint)weakPoint.GetComponent("BossPartWeakPoint")).SetPartComponent(this);
		}
		// SetStrong()
		SetWeak();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool IsWeak() {
		return isWeak;
	}
	
	public bool IsBroken() {
		return isBroken;
	}

	public void SetWeak() {
		isBroken = false;
		isWeak = true;
		renderer.material.mainTexture = weakTexture;
		collider.enabled = true;
		if (weakPoint) {
			weakPoint.collider.enabled = true;
		}
	}

	public void SetStrong() {
		isBroken = false;
		isWeak = false;
		renderer.material.mainTexture = strongTexture;
		collider.enabled = true;
		if (weakPoint) {
			weakPoint.collider.enabled = false;
		}
	}

	public void SetBroken() {
		isBroken = true;
		isWeak = false;
		renderer.material.mainTexture = brokenTexture;
		collider.enabled = false;
		if (weakPoint) {
			weakPoint.collider.enabled = false;
		}
		
		if (transform.parent) {
			((AbstractBoss)transform.parent.gameObject.GetComponent("AbstractBoss")).PartBroken(gameObject);
		}
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
