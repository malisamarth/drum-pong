using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class OpponentPadScript : MonoBehaviour
{
    public static OpponentPadScript Instance { get; private set; }


    private BallScript ballScript;
    private PlayerPadScript playerPadScript;

    private float speed = 5f;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        playerPadScript = PlayerPadScript.Instance.GetComponent<PlayerPadScript>();
        ballScript = BallScript.Instance.GetComponent<BallScript>();
    }

    private void Update() {

        /*if (playerPadScript.isBallTouched && ballScript.transform.position.x <= 3.68f) {
            Debug.Log("now hiting");
            gameObject.transform.position = new Vector2(-8f, positionY * 0.80f);
        } else {
            Debug.Log("now waiting");
            gameObject.transform.position = new Vector2(-8f, positionY * 0.30f);
        }*/

        //if (transform.position.y < 3.93 || transform.position.y > -3.93) {
            float targetY = ballScript.transform.position.y;
            Vector2 currentPos = transform.position;
            Vector2 targetPos = new Vector2(currentPos.x, targetY);

            // Move smoothly
            Vector2 newPos = Vector2.MoveTowards(currentPos, targetPos, speed * 1.4f * Time.deltaTime);

            // Clamp Y so it never leaves the screen
            newPos.y = Mathf.Clamp(newPos.y, -3.93f, 3.93f);

            transform.position = newPos;
       // }



    }

    private void OnCollisionEnter2D(Collision2D collision) {
        playerPadScript.isBallTouched = false;
    }

}

/*private float speed = 5f;
private float speedMultiplier = 3f;
private void Update() {

    //if (/*Keyboard.current[Key.UpArrow].isPressed ||*/ //Keyboard.current[Key.W].isPressed) {
                                                         //  transform.position += new Vector3(0, speed * speedMultiplier, 0) * Time.deltaTime;
                                                         // }

//  if (/*Keyboard.current[Key.DownArrow].isPressed ||*/ Keyboard.current[Key.S].isPressed) {
// transform.position += new Vector3(0, -speed * speedMultiplier, 0) * Time.deltaTime;
// }

// }