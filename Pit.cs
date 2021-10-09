using Godot;
using System;

public class Pit : Area
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    Spatial spawnLocation;
    public override void _Ready()
    {
        
    }

    public void OnPitBodyEntered(Node body)
    {
        if (body.Name == "PlayerRB")
        {
            Player p1 = body as Player;
            spawnLocation = GetNode("../Levels/" + p1.progress.ToString() + "/Spawn") as Spatial;
            RigidBody rbp1 = body as RigidBody;
            rbp1.AxisLockLinearY = true;
            rbp1.LinearVelocity = new Vector3(0,0,0);
            rbp1.AngularVelocity = new Vector3(0,0,0);
            rbp1.AxisLockLinearY = false;

            Spatial spawn = spawnLocation.GetParent() as Spatial;
            Vector3 sVec = spawn.Translation;
            sVec -= new Vector3(0, 108.5f, 0);
            p1.respawn = true;
            p1.respawnLocation = spawnLocation.Translation + sVec;

        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
