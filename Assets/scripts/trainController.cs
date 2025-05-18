// using UnityEngine;

// public class TrainController : MonoBehaviour
// {
//     [Header("Movement Settings")]
//     public float maxSpeed = 10f;
//     public float acceleration = 2f;
//     public float rotationSpeed = 5f;

//     [HideInInspector]
//     public int CurrentWaypointIndex;

//     private RailSystem _railSystem;
//     private Rigidbody _rb;
//     private float _currentSpeed;

//     void Start()
//     {
//         _rb = GetComponent<Rigidbody>();
//         _railSystem = FindObjectOfType<RailSystem>();
//         CurrentWaypointIndex = 0;
//     }

//     void FixedUpdate()
//     {
//         if (_railSystem == null)
//             return;

//         _currentSpeed = Mathf.MoveTowards(
//             _currentSpeed,
//             maxSpeed,
//             acceleration * Time.fixedDeltaTime
//         );

//         Vector3 targetDirection = _railSystem.GetCurrentSegmentDirection();

//         _rb.MovePosition(_rb.position + targetDirection * (_currentSpeed * Time.fixedDeltaTime));
//         Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
//         _rb.MoveRotation(
//             Quaternion.Slerp(_rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime)
//         );

//         CheckWaypointReached();
//     }

//     void CheckWaypointReached()
//     {
//         Vector3 nextPoint = _railSystem.GetNextPoint(out int currentIndex);
//         if (Vector3.Distance(transform.position, nextPoint) < 1f)
//         {
//             CurrentWaypointIndex = (currentIndex + 1) % _railSystem.GetWaypointsCount();
//         }
//     }
// }
