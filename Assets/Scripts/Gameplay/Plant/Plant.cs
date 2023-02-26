using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Plant : MonoBehaviour
{
    private Transform _player;
    private SpriteRenderer _renderer;
    private float _sunkenTime = 0;
    [field: SerializeField] public int CurrentStage {get; set;}
    [field: SerializeField] public Sprite[] PlantStages {get; set;}
    public ParticleSystem VfxGetIn, VfxSunken;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _renderer = GetComponent<SpriteRenderer>();
        CurrentStage = Random.Range(0, 2);
    }

    void Update()
    {
        CurrentStage = Mathf.Clamp(CurrentStage, 0, 2);
        _renderer.sprite = PlantStages[CurrentStage];

        if (Vector2.Distance(transform.position, _player.position) <= 1)
        {
            SunkenTime (5);
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
            VfxGetIn.Play ();
        }    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CurrentStage ++;
            VfxSunken.Play ();
        }
    }
}
