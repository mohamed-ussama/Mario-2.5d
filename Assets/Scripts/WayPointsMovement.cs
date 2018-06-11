
using UnityEngine;

public class WayPointsMovement : MonoBehaviour {

    public Transform Point1;
    public Transform Point2;
    Transform target;
    public float speed;
    public float step;

    private void Start()
    {
        transform.position = Point1.position;
        target= Point2;
    }

    void Update () {
        step = speed * Time.deltaTime;
        if (transform.position!=target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            
        }else if (target.position == Point2.position)
        {
            target = Point1;
        }
        else if (target.position == Point1.position)
        {
            target = Point2;
        }
    }
}
