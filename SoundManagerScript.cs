using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SoundManagerScript : MonoBehaviour {

    [SerializeField] private AudioClip pianoSound_1;
    [SerializeField] private AudioClip pianoSound_2;
    [SerializeField] private AudioClip pianoSound_3;
    [SerializeField] private AudioClip pianoSound_4;
    [SerializeField] private AudioClip pianoSound_5;
    [SerializeField] private AudioClip pianoSound_6;

    [SerializeField] private AudioClip snareDrum_1;
    [SerializeField] private AudioClip snareDrum_2;

    [SerializeField] private AudioClip outOfRangeHitHat;

    private void Start () {
        CeilScript.Instance.onCeilCollision += CeilScript_onCeilCollision;
        GroundScript.Instance.onGroundCollision += Instance_onGroundCollision;
        BallScript.Instance.onPlayerPadCollision += Instance_onPlayerPadCollision;
        BallScript.Instance.onOpponentPadCollision += Instance_onOpponentPadCollision;
        BallScript.Instance.outOfRangePlayer += Instance_outOfRangePlayer;
    }

    private void Instance_outOfRangePlayer(object sender, System.EventArgs e) {
        AudioSource.PlayClipAtPoint(outOfRangeHitHat, Camera.main.transform.position);
    }

    private void Instance_onOpponentPadCollision(object sender, System.EventArgs e) {
        AudioSource.PlayClipAtPoint(snareDrum_2, Camera.main.transform.position);
    }

    private void Instance_onPlayerPadCollision(object sender, System.EventArgs e) {
        AudioSource.PlayClipAtPoint(snareDrum_2, Camera.main.transform.position);
    }

    private void Instance_onGroundCollision(object sender, System.EventArgs e) {
        randomPianoClip();
    }

    private void CeilScript_onCeilCollision(object sender, System.EventArgs e) {
        randomPianoClip();
    }

    private void randomPianoClip() {
        int randInclusive = Random.Range(1, 7);

        switch (randInclusive) {
            case 1:
                AudioSource.PlayClipAtPoint(pianoSound_1, Camera.main.transform.position);
                break;
            case 2:
                AudioSource.PlayClipAtPoint(pianoSound_2, Camera.main.transform.position);
                break;
            case 3:
                AudioSource.PlayClipAtPoint(pianoSound_3, Camera.main.transform.position);
                break;
            case 4:
                AudioSource.PlayClipAtPoint(pianoSound_4, Camera.main.transform.position);
                break;
            case 5:
                AudioSource.PlayClipAtPoint(pianoSound_5, Camera.main.transform.position);
                break;
            case 6:
                AudioSource.PlayClipAtPoint(pianoSound_6, Camera.main.transform.position);
                break;
            default:
                AudioSource.PlayClipAtPoint(pianoSound_1, Camera.main.transform.position);
                break;
        }


    }

}


