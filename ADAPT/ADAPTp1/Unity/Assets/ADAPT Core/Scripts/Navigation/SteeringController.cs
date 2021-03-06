using UnityEngine;
using System.Collections;

public enum SteeringState
{
    Stopped,
    Navigating,
    Arriving
}

public enum OrientationQuality
{
    Low,
    High
}

public enum OrientationBehavior
{
    LookForward,
    LookAtTarget,
    None
}

[System.Serializable]
public abstract class SteeringController : MonoBehaviour
{
    protected static readonly float TURN_EPSILON = 0.98f;
    protected static readonly float STOP_EPSILON = 0.15f;

    protected Vector3 lastPosition = Vector3.zero;
    protected Vector3 target = Vector3.zero;
    public abstract Vector3 Target { get; set; }

    // Whether we're attached to the navmesh
    protected bool attached = true;
    public abstract bool Attached { get; set; }

    [HideInInspector]
    public Quaternion desiredOrientation = Quaternion.identity;

    // Steering Parameters
    public float YOffset = 0.0f;
    public float radius = 0.6f;
    public float height = 2.0f;
    public float stoppingRadius = 0.4f;
    public float arrivingRadius = 3.0f;
    public float acceleration = 2.0f;
    public float maxSpeed = 2.2f;
    public float minSpeed = 0.5f;

    public bool SlowArrival = true;

    public bool ShowDragGizmo = false;
    public bool ShowAgentRadiusGizmo = false;
    public bool ShowTargetRadiusGizmo = false;

    // Orientation Parameters
    public float driveSpeed = 120.0f;
    public float dragRadius = 0.5f;
    public bool planar = true;
    public bool driveOrientation = true;

    public OrientationQuality orientationQuality =
        OrientationQuality.High;
    public OrientationBehavior orientationBehavior =
        OrientationBehavior.LookForward;

    public abstract bool IsAtTarget();
    public abstract bool IsStopped();
    public abstract bool HasArrived();
    public abstract bool CanReach(Vector3 target);
    public abstract void Stop();

    public bool IsFacing()
    {
        Quaternion orientation = transform.rotation;
        Quaternion desired = this.desiredOrientation;

        if (Mathf.Abs(Quaternion.Dot(desired, orientation)) > TURN_EPSILON)
            return true;
        return false;
    }

    public void SetDesiredOrientation(Vector3 target)
    {
        Vector3 difference =
            LocomotionUtil.ProjectOntoPlane(
                target - transform.position, 
                Vector3.up);

        this.desiredOrientation = Quaternion.LookRotation(difference);
    }
}