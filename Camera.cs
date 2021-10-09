using Godot;
using System;
public class Camera : Godot.ClippedCamera
{
    private Vector3 offset;
    RigidBody playerRB;
    private float initialXRotation;
    private float maxVerticalAngle;
    private bool useFloorNormal;
    float horizontal;
    float vertical;
    float camrot_h = 0;
    Spatial h;

    public override void _Ready()
    {
        playerRB = GetNode("../../../../RigidBody") as RigidBody;
        h = GetNode("../../../h") as Spatial;

        offset = Translation - playerRB.Translation;
        horizontal = 0.0f;
        vertical = 0.0f;
        
    }

    public override void _Input(InputEvent @event)
    {
        InputEventMouseMotion motion = @event as InputEventMouseMotion;
        if (motion != null)
        {
            if (Input.IsMouseButtonPressed(2)) {

                var movement = motion.Relative;
                camrot_h += -movement.x;
            }


        }
    }
    public override void _PhysicsProcess(float delta)
    {


        Translation = playerRB.Translation + new Vector3(0,0, offset.z);
        h.RotationDegrees = new Vector3(h.RotationDegrees.x, camrot_h, h.RotationDegrees.z);
        
    }

    void CameraTilt()
    {
    }
}
