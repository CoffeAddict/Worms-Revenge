using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    // public float movementSpeed;
    public float rotationSpeed;
    // public float topSpeed;
    // public float stopRate;
    public GameObject pathParent = null;
    private Transform[] pathList;
    private bool hasPath;
    private Transform currentWaypoint = null;
    private int currentWaypointIndex = -1;
    private bool followWaypoint = false;

    Rigidbody2D rb2D;

    void Awake () {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start () {
        hasPath = pathParent.transform.childCount > 0;
        if (hasPath) {
            pathList = pathParent.GetComponentsInChildren<Transform>();

            // Remove first item of array (parents transform is added to array)
            List<Transform> list = new List<Transform>(pathList);
            list.RemoveAt(0);
            pathList = list.ToArray();

            updateWaypoint();
        }

    }

    void FixedUpdate () {
        if (followWaypoint == true) followCurrentWaypoint();
    }

    void updateWaypoint () {
        currentWaypoint = currentWaypoint == null ? pathList[0] : pathList[currentWaypointIndex++];
        followWaypoint = true;
    }

    void followCurrentWaypoint () {
        Vector3 targetRotation = currentWaypoint.position - transform.position;

        float rotationModifier = 90;

        float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg - rotationModifier;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}



// check if waypoints list is not empty, if so, stay steady
// follow waypoints
// if lookForPlayer is checked, check if player is around and there's no object in between (raycast)
// while following player, ignore waypoints for 5 seconds and go back to last waypoint (idk how)

