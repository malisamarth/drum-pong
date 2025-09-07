using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPadScript : MonoBehaviour {

    public static PlayerPadScript Instance { get; private set; }

    private float speed = 5f;
    private float speedMultiplier = 4f;

    public bool isBallTouched = false;

    private void Awake() {
        Instance = this;
    }
    private void Update() {
        
        if (Keyboard.current[Key.UpArrow].isPressed && transform.position.y < 3.93/*|| Keyboard.current[Key.W].isPressed*/) {
            transform.position += new Vector3(0, speed * speedMultiplier, 0) * Time.deltaTime;
        }

        if (Keyboard.current[Key.DownArrow].isPressed && transform.position.y > -3.93/*|| Keyboard.current[Key.S].isPressed*/) {
            transform.position += new Vector3(0, -speed * speedMultiplier, 0) * Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isBallTouched = true;
    }

}
