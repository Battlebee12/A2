using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        Debug.Log("detected collisions");
        Debug.Log($"{triggeredBody.gameObject.name} collided with {gameObject.name} and stopped moving.");

        // Get the Rigidbody of the ball
        Rigidbody ballRigidBody = triggeredBody.gameObject.GetComponent<Rigidbody>();

        // Store the velocity magnitude before resetting the velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        // Reset the linear and angular velocity
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        // Was facing problems with the applying force to z axis, as the colliders got messed up whenever
        // i changed the direction to z axis
        Vector3 newVelocity = Vector3.forward * velocityMagnitude;
        ballRigidBody.linearVelocity = newVelocity;
    }
}