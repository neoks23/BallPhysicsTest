using Godot;
using System;

public class CamRoot : Spatial
{

    ClippedCamera camera;
    float camrot_h = 0;
    float camrot_v = 0;
    int cam_v_max = 75;
    int cam_v_min = 20;
    float h_sensitivity = 0.1f;
    float v_sensitivity = 0.1f;
    float h_acceleration = 10.0f;
    float v_acceleration = 10.0f;
    RigidBody playerRB;
    private float offset;
    Spatial h;
    Spatial v;
    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Captured);
        camera = GetNode("h/v/Camera") as ClippedCamera;
        camera.AddException(GetParent());
        playerRB = GetNode("../PlayerRB") as RigidBody;
        h = GetNode("h") as Spatial;
        v = GetNode("h/v") as Spatial;
        Vector3 offset = Translation - playerRB.Translation;
        this.offset = offset.z;
    }

    public override void _UnhandledInput(InputEvent @event)
    {

        if (@event is InputEventMouseButton)
        {
            InputEventMouseButton emb = (InputEventMouseButton)@event;

            if (emb.IsPressed())
            {
                if (camera.Translation < new Vector3(0, 0, -50.0f))
                {
                    camera.Translation = new Vector3(0, 0, -50.0f);
                }
                else if (camera.Translation > new Vector3(0, 0, 0.0f))
                {
                    camera.Translation = new Vector3(0, 0, 0.0f);
                }
                else
                {
                    if (emb.ButtonIndex == (int)ButtonList.WheelUp)
                    {
                        camera.Translation += new Vector3(0, 0, 2.0f);
                    }
                    if (emb.ButtonIndex == (int)ButtonList.WheelDown)
                    {
                        camera.Translation -= new Vector3(0, 0, 2.0f);
                    }

                }
            }
        }
    }
    public override void _Input(InputEvent @event)
    {
        InputEventMouseMotion motion = @event as InputEventMouseMotion;
        if (motion != null)
        {
            if (Input.IsMouseButtonPressed(2))
            {

                var movement = motion.Relative;
                camrot_h += -movement.x * h_sensitivity;
                camrot_v += movement.y * v_sensitivity;
            }

        }
    }
    public override void _PhysicsProcess(float delta)
    {


        Translation = playerRB.Translation + new Vector3(0, 0, offset);

        camrot_v = Mathf.Clamp(camrot_v, cam_v_min, cam_v_max);


        h.RotationDegrees = new Vector3(h.RotationDegrees.x, Mathf.Lerp(h.RotationDegrees.y, camrot_h, delta * h_acceleration), h.RotationDegrees.z);
        v.RotationDegrees = new Vector3(Mathf.Lerp(v.RotationDegrees.x, camrot_v, delta * v_acceleration), v.RotationDegrees.y, v.RotationDegrees.z);
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
