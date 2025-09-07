using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CeilScript : MonoBehaviour {

    public static CeilScript Instance {  get; private set; }

    public event EventHandler onCeilCollision;

    private void Awake() {
        Instance = this;
    }
    private void OnCollisionEnter2D(Collision2D collision2D) {
        if (collision2D.gameObject.TryGetComponent(out BallScript ballScript)) {
            onCeilCollision?.Invoke(this, EventArgs.Empty);
        }
    }

}

