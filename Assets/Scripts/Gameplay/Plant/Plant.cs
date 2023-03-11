using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Plant : MonoBehaviour
{
    private Score _score;
    private int SFplay;
    private Transform _player;
    private PlayerFrog _playerScript;
    private SpriteRenderer _renderer;
    private float _sunkenTime = 0;
    [field: SerializeField] public int AddScore {get; set;}
    [field: SerializeField] public int CurrentStage {get; set;}
    [field: SerializeField] public Sprite[] PlantStages {get; set;}
    public ParticleSystem VfxGetIn, VfxSunken, VfxBubbles;
    public AudioSource[] SFSplash;

    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("GameController").transform.GetChild(1).GetComponent<Score>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerScript = _player.GetComponent<PlayerFrog>();
        _renderer = GetComponent<SpriteRenderer>();
        CurrentStage = Random.Range(0, 2);
    }

    void Update()
    {
        CurrentStage = Mathf.Clamp(CurrentStage, 0, 2);
        _renderer.sprite = PlantStages[CurrentStage];

        if (Vector2.Distance(transform.position, _player.position) <= 1)
        {
            SunkenTime (10);

            // Game over
            if (CurrentStage >= 2)
            {
                _player.GetComponent<PlayerFrog>().live = false;
                VfxBubbles.Play ();
            }
        }

        PlayerMoveTo ();
    }

    void PlayerMoveTo ()
    {
        if (CurrentStage != 2)
        {
            if (_playerScript.Distance(_playerScript.Point, transform.position) <= 2.5f)
            {
                _playerScript.GoTo = transform;
            }
            else if (_playerScript.Distance(_playerScript.Point, transform.position) > 2.5f && _playerScript.Distance(_playerScript.Point, transform.position) <= 2.7f)
            {
                _playerScript.GoTo = null;
            }
        }
    }

    void SunkenTime (float maxTime)
    {
        _sunkenTime += 1*Time.deltaTime;
        if (_sunkenTime >= maxTime)
        {
            CurrentStage ++;
            VfxSunken.Play ();
            _sunkenTime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            _sunkenTime = 0;
            VfxGetIn.Play ();
            if (SFplay == 0)
            {
                SFSplash[Random.Range(0, SFSplash.Length)].Play ();
                SFplay = 1;
            }
            _score.Score_ += AddScore;
        }    
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player" && _sunkenTime >= .5f)
        {
            CurrentStage ++;
            VfxSunken.Play ();
            SFplay = 0;
        }
    }
}
