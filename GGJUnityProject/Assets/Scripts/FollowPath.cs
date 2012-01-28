using UnityEngine;
using System;
using System.Collections;


public class FollowPath : MonoBehaviour {
	public string pathName;
	public float speed = 10;
	public bool autostart = false;
	public bool looped = false;
	public bool KillOnEnd = false;
	public bool lookWhereYoureGoing = false;
	
	private float progress;
	private int spline;
	private Vector3 lastDerivative;
	private bool paused;
	private Vector3[] points;
	
	// Use this for initialization
	void Start () {
		GameObject path = GameObject.Find(pathName);
		points = new Vector3[path.transform.childCount];
		string[] names = new string[path.transform.childCount];

		int index = 0;
		foreach (Transform child in path.transform) {
			points[index] = child.position;
			names[index] = child.name;
			index++;
		}
		Array.Sort(names, points);
		
		RestartFollowing();
		paused = !autostart;
	}
	
	// Update is called once per frame
	void Update () {
		if (!paused) {
			Vector3 p0, p1, p2;
			p0 = points[spline];
			p1 = points[spline+1];
			if (spline == points.Length - 2) {
				p2 = points[0];
			} else {
				p2 = points[spline+2];
			}
			transform.position = QBezier(p0, p1, p2, progress);
			if (lookWhereYoureGoing) {
				Vector3 derivative = QBezierDerivative(p0, p1, p2, progress);
				Vector3 look = new Vector3(derivative.x, derivative.y, 0);
				Vector3 up = Vector3.Cross(look, Vector3.forward);
				look = Vector3.Cross(look, up);
				transform.rotation = Quaternion.LookRotation(look, up);
			}
			
			float baseSpeed = speed / 1000.0f;
			progress += baseSpeed;
			while (progress >= 1.0f) {
				progress -= 1.0f;
				spline += 2;
				if (!looped && spline >= points.Length - 2) {
					paused = true;
					if (KillOnEnd) {
						Destroy(this.gameObject);
					}
				} else if (looped && spline >= points.Length - 1) {
					spline = 0;
				}
			}
		}
	}

	public void StartFollowing() {
		paused = false;
	}
	
	public void StopFollowing() {
		paused = true;
	}
	
	public void RestartFollowing() {
		// Move the game object to the start of the path
		spline = 0;
		progress = 0.0f;
		transform.position = points[0];
	}

	private Vector3 QBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t) {
	// 	B(t) = (1 - t)^2P0 + 2(1 - t)tP1 + t^2P2, 0 <= t <= 1
		float tsquared = t * t;
		return new Vector3(
			(1 - t) * (1 - t) * p0.x + 2 * (t - tsquared) * p1.x + tsquared * p2.x,
			(1 - t) * (1 - t) * p0.y + 2 * (t - tsquared) * p1.y + tsquared * p2.y,
			(1 - t) * (1 - t) * p0.z + 2 * (t - tsquared) * p1.z + tsquared * p2.z
		);
	}

	private Vector3 QBezierDerivative(Vector3 p0, Vector3 p1, Vector3 p2, float t) {
	// 	B'(t) = 2(1 - t)(P1 - P0) + 2t(P2 - P1)
		return new Vector3(
			2 * (1 - t) * (p1.x - p0.x) + 2 * t * (p2.x - p1.x),
			2 * (1 - t) * (p1.y - p0.y) + 2 * t * (p2.y - p1.y),
			2 * (1 - t) * (p1.z - p0.z) + 2 * t * (p2.z - p1.z)
		);
	}

	
}
