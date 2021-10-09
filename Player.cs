using Godot;
using System;

public class Player : RigidBody
{
    [Export]
    public int progress = 1;
    public bool respawn;
    public Vector3 respawnLocation;
    float move_speed = 2.0f;
    float max_speed = 50.0f;
    ClippedCamera camera;
    
    public override void _Ready()
    {
        respawn = false;
        respawnLocation = new Vector3(0, 0, 0);
        camera = GetNode("../CamRoot/h/v/Camera") as ClippedCamera;
    }

    public override void _Process(float delta)
    {

        if (respawn)
        {
            Translation = respawnLocation;
            respawn = false;
        }
        else
        {
            Vector3 aVel = AngularVelocity;

            if (aVel.Length() > max_speed)
            {
                AngularVelocity = aVel.Normalized() * max_speed;
            }
            if (Input.IsActionPressed("ui_left"))
            {
                ApplyCentralImpulse(camera.GlobalTransform.basis.x * -move_speed);
            }
            if (Input.IsActionPressed("ui_right"))
            {
                ApplyCentralImpulse(camera.GlobalTransform.basis.x * move_speed);
            }

            if (Input.IsActionPressed("ui_down"))
            {
                ApplyCentralImpulse(camera.GlobalTransform.basis.z * move_speed);
            }
            if (Input.IsActionPressed("ui_up"))
            {
                ApplyCentralImpulse(camera.GlobalTransform.basis.z * -move_speed);
            }
        }


    }

}
