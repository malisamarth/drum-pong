using System;
using UnityEngine;

public class GroundScript : MonoBehaviour {
    public static GroundScript Instance { get; private set; }

    public event EventHandler onGroundCollision;

    private void Awake() {
        Instance = this;
    }
    private void OnCollisionEnter2D(Collision2D collision2D) {
        if (collision2D.gameObject.TryGetComponent(out BallScript ballScript)) {
            onGroundCollision?.Invoke(this, EventArgs.Empty);
        }
    }
}
