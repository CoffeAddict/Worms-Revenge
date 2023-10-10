using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float rotationOffset;
    public float topSpeed;
    public float stopRate;
    public GameObject pathParent = null;
    public float waypointSwitchRange = 4;
    public bool followWaypoint = false;
     Transform[] pathList;
     bool hasPath;
     Transform currentWaypoint = null;
     int currentWaypointIndex = 0;

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

            UpdateWaypoint();
        }

    }

    void FixedUpdate () {
        if (followWaypoint == true) {
            CheckWaypointDistance(currentWaypoint);
            RotateToWaypoint();
            GoForward();
        };

    }

    void CheckWaypointDistance (Transform waypoint) {
        float distance = Vector3.Distance (waypoint.position, transform.position);

        if (distance <= waypointSwitchRange) UpdateWaypoint();
    }

    void UpdateWaypoint () {
        rb2D.velocity = new Vector3(rb2D.velocity.x / stopRate , rb2D.velocity.y / stopRate);
        rb2D.angularVelocity = rb2D.angularVelocity / stopRate ;

        if (currentWaypointIndex >= pathList.Length) currentWaypointIndex = 0;
        currentWaypoint = currentWaypoint == null ? pathList[0] : pathList[currentWaypointIndex];

        currentWaypointIndex++;

        followWaypoint = true;
    }

    void RotateToWaypoint () {
        Vector3 targetPosition = currentWaypoint.position - transform.position;

        // I had to do some research to understand this
        // Mathf.Atan2 returns the angle in radians whose tangent is y/x (the angle were we want to look at)
        // Mathf.Rad2Deg transforms radians to degrees
        float angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg - rotationOffset;

        // Returns a rotation on the Z angle (Vector3.forward)
        Quaternion desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Interpolates a rotation from current rotation to desiredRotation on an specified time
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }

    void GoForward () {
        rb2D.AddRelativeForce(new Vector2(0, movementSpeed));

        if (rb2D.velocity.x > topSpeed) rb2D.velocity = new Vector2(topSpeed, rb2D.velocity.y);
        if (rb2D.velocity.y > topSpeed) rb2D.velocity = new Vector2(rb2D.velocity.x, topSpeed);

        if (rb2D.velocity.x < (topSpeed * -1)) rb2D.velocity = new Vector2((topSpeed * -1), rb2D.velocity.y);
        if (rb2D.velocity.y < (topSpeed * -1)) rb2D.velocity = new Vector2(rb2D.velocity.x, (topSpeed * -1));
    }
}
