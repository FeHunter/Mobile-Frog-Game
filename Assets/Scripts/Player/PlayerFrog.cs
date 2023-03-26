using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFrog : MonoBehaviour
{
    [field: SerializeField] private float _range {get; set;} // 4.5f
    private float _noRepeat, _waitToMove;
    private SpriteRenderer _sprite;
    public Transform? GoTo {get; set;}
    public Vector2 Point {get; set;}
    [field: SerializeField] public bool Playing {get; set;}
    [field: SerializeField] public bool live {get; set;}
    [field: SerializeField] public float MoveTime { get; set; }
    [field: SerializeField] public LineRenderer sign {get; set;}
    [field: SerializeField] public PathGenerator pathGenerator {get; set;}
    public ParticleSystem VfxPointToGo, VfxGameOver;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!live)
        {
            // Game Over
            if (_noRepeat == 0)
            {
                _sprite.enabled = false;
                VfxGameOver.Play ();
                Invoke ("ReloadScene", 5);
                _noRepeat = 1;   
            }
        }
        else 
        {
            if (!pathGenerator.EndGame && Playing)
            {
                // In Game
                Sign ();
            }
        }
    }

    void ReloadScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void MovementControl ()
    {
        if (Input.GetMouseButton(0) )
        {
            Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Point = new Vector2 (Mathf.Clamp (Point.x, transform.position.x-_range, transform.position.x+_range), Mathf.Clamp (Point.y, transform.position.y-_range, transform.position.y+_range));
        }
        // Go to position
        else if (_waitToMove >= .5f)
        {
            MoveTo ();
        }
    }

    void Sign ()
    {
        MovementControl ();

        
        if (GoTo != null && Distance(transform.position, GoTo.position) > 2f)
        {
            VfxPointToGo.Play ();
            VfxPointToGo.transform.position = new Vector3 (Point.x, Point.y, 0);
        }
        else
        {
            VfxPointToGo.Stop ();
        }

        
        _waitToMove += 1*Time.deltaTime;

        
        if (Input.GetMouseButton(0))
        {
            sign.enabled = true;
            sign.SetPosition(0, transform.position);
            sign.SetPosition(1, Point);
            VfxPointToGo.Play ();
        }
        else
        {
            sign.enabled = false;
            VfxPointToGo.Stop ();
        }
        
    }

    void MoveTo ()
    {
        if (Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), Point) <= 2.5f){
            transform.position = (GoTo != null && Distance(transform.position, GoTo.position) > 2f) ? new Vector3(GoTo.position.x, GoTo.position.y, 0) : transform.position;
            _waitToMove = 0;
        }else{
            _waitToMove = 0;
        }
    }

    public float Distance (Vector2 obj1, Vector2 obj2)
    {
        return Vector2.Distance (obj1, obj2);
    }
}
