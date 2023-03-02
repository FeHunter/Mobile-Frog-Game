using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFrog : MonoBehaviour
{
    [field: SerializeField] private float _range {get; set;} // 4.5f
    private float _waitToMove;
    public Transform? GoTo {get; set;}
    public Vector2 Point {get; set;}
    [field: SerializeField] public bool live {get; set;}
    [field: SerializeField] public float MoveTime { get; set; }
    [field: SerializeField] public LineRenderer sign {get; set;}
    [field: SerializeField] public ParticleSystem VfxPointToGo {get; set;}
    void Start()
    {

    }

    void Update()
    {
        Sign ();

        if (!live)
        {
            Invoke ("ReloadScene", 2);
        }
    }

    void ReloadScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Sign ()
    {
        Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Point = new Vector2 (Mathf.Clamp (Point.x, transform.position.x-_range, transform.position.x+_range), Mathf.Clamp (Point.y, transform.position.y-_range, transform.position.y+_range));

        if (GoTo != null && Distance(GoTo) > 2f)
        {
            VfxPointToGo.Play ();
            VfxPointToGo.transform.position = new Vector3 (Point.x, Point.y, 0);
        }
        else
        {
            VfxPointToGo.Stop ();
        }

        _waitToMove += 1*Time.deltaTime;

        if (_waitToMove >= MoveTime)
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

        // Go to position
        if (Input.GetMouseButtonDown(0) && _waitToMove >= MoveTime)
        {
            transform.position = (GoTo != null && Distance(GoTo) > 2f) ? new Vector3(GoTo.position.x, GoTo.position.y, 0) : transform.position;
            _waitToMove = 0;
        }
    }

    float Distance (Transform obj)
    {
        return Vector2.Distance (transform.position, obj.position);
    }
}
