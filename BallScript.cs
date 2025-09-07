using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallScript : MonoBehaviour {

    public static BallScript Instance { get; private set; }


    public event EventHandler addOpponentScore;
    public event EventHandler addPlayertScore;

    public event EventHandler outOfRangePlayer;

    public event EventHandler onPlayerPadCollision;
    public event EventHandler onOpponentPadCollision;

    private PlayerPadScript playerPadScript;
    private OpponentPadScript opponentPadScript;
    private ScoreManagerScript scoreManagerScript;

    [SerializeField] private Rigidbody2D ballRb;
    private float speed = 10f;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        ballRb.linearVelocity = new Vector2(1f, 0f).normalized * speed;
        playerPadScript = PlayerPadScript.Instance.GetComponent<PlayerPadScript>();
        opponentPadScript = OpponentPadScript.Instance.GetComponent<OpponentPadScript>();
        scoreManagerScript = ScoreManagerScript.Instance.GetComponent<ScoreManagerScript>();
    }

    private void Update() {

        if (gameObject.transform.position.x >= 9.3f) {
            gameObject.transform.position = new Vector2 (0, 0);
            ballRb.linearVelocity = new Vector2(1f, 0f).normalized * speed;
            playerPadScript.transform.position = new Vector2(7.96f, 0f);
            opponentPadScript.transform.position = new Vector2(-8f, 0f);
            addOpponentScore?.Invoke(this, EventArgs.Empty);
            outOfRangePlayer?.Invoke(this, EventArgs.Empty);
        } 

        if (gameObject.transform.position.x <= -9.3f) {
            playerPadScript.isBallTouched = true;
            gameObject.transform.position = new Vector2(0, 0);
            ballRb.linearVelocity = new Vector2(1f, 0f).normalized * speed;
            opponentPadScript.transform.position = new Vector2(-8f, 0f);
            playerPadScript.transform.position = new Vector2(7.96f, 0f);
            addPlayertScore?.Invoke(this, EventArgs.Empty);
            outOfRangePlayer?.Invoke(this, EventArgs.Empty);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision2D) {
            float hitFactor = (transform.position.y - collision2D.transform.position.y) / collision2D.collider.bounds.size.y;
            // hitFactor = -1 (bottom of paddle) → ball goes down
            // hitFactor = +1 (top of paddle) → ball goes up

            Vector2 dir = new Vector2(
                Mathf.Sign(ballRb.linearVelocity.x), // keep moving left/right
                hitFactor
            ).normalized;

            ballRb.linearVelocity = dir * speed;

        if (collision2D.gameObject.TryGetComponent(out PlayerPadScript playerPadScript)) {
            onPlayerPadCollision?.Invoke(this, EventArgs.Empty);
        }

        if (collision2D.gameObject.TryGetComponent(out OpponentPadScript opponentPadScript)) {
            onOpponentPadCollision?.Invoke(this, EventArgs.Empty);
        }

    }

}
