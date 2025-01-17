using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRB : MonoBehaviour
{
    public float pushpower=2.0f;
    private float targetMass;
    // Start is called before the first frame update
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        targetMass = body.mass;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushpower/targetMass;
    }
}
