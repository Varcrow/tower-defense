using UnityEngine;

public class Follow : MonoBehaviour
{
  public Transform[] waypoints;
  public float moveSpeed = 2f;
  private int waypointIndex = 0;

  void Start()
  {
    transform.position = waypoints[waypointIndex].transform.position;
  }

  void Update()
  {
    if (waypointIndex <= waypoints.Length - 1)
    {
      transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

      if (transform.position == waypoints[waypointIndex].transform.position)
      {
        waypointIndex++;
      }
    }
  }
}
