// using UnityEngine;

// public class RailSystem : MonoBehaviour
// {
//     [SerializeField]
//     private Transform[] waypoints;

//     [SerializeField]
//     private TrainController train;

//     public Vector3 GetNextPoint(out int currentIndex)
//     {
//         currentIndex = train.CurrentWaypointIndex;
//         int nextIndex = (currentIndex + 1) % waypoints.Length;
//         return waypoints[nextIndex].position;
//     }

//     public Vector3 GetCurrentSegmentDirection()
//     {
//         int index = train.CurrentWaypointIndex;
//         Vector3 start = waypoints[index].position;
//         Vector3 end = waypoints[(index + 1) % waypoints.Length].position;
//         return (end - start).normalized;
//     }

//     void OnDrawGizmos()
//     {
//         if (waypoints == null)
//             return;

//         Gizmos.color = Color.red;
//         for (int i = 0; i < waypoints.Length; i++)
//         {
//             Vector3 next = waypoints[(i + 1) % waypoints.Length].position;
//             Gizmos.DrawLine(waypoints[i].position, next);
//         }
//     }
// }
