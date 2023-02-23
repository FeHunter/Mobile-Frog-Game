using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrog : MonoBehaviour
{
    public float Range;
    public LineRenderer sign;
    public ParticleSystem VfxPointToGo;
    public Transform? GoTo;
    [HideInInspector] public Vector2 point;

    void Start()
    {
    }

    void Update()
    {
        Sign ();
    }

    void Sign ()
    {
         point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point = new Vector2 (Mathf.Clamp (point.x, transform.position.x-Range, transform.position.x+Range), Mathf.Clamp (point.y, transform.position.y-Range, transform.position.y+Range));
        // RaycastHit2D hit = Physics2D.Raycast (transform.position, point, Range, 1 << LayerMask.NameToLayer("Plant"));

        if (GoTo != null && Distance(GoTo) > 2f)
        {
            VfxPointToGo.Play ();
            VfxPointToGo.transform.position = new Vector3 (point.x, point.y, 0);
        }
        else
        {
            VfxPointToGo.Stop ();
        }



        sign.SetPosition(0, transform.position);
        sign.SetPosition(1, point);

        // Go to position
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = (GoTo != null && Distance(GoTo) > 2f) ? new Vector3(GoTo.position.x, GoTo.position.y, 0) : transform.position;
        }
    }

    float Distance (Transform obj)
    {
        return Vector2.Distance (transform.position, obj.position);
    }
}
