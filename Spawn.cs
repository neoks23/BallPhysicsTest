using Godot;
using System;

public class Spawn : Spatial
{
    public int level = 0;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        level = Convert.ToInt32(GetParent().Name);
    }

    public void OnSpawnHitboxBodyEntered(Node body)
    {
        if (body.Name == "PlayerRB")
        {
            GD.Print("Set spawn position " + level);
            Player p1 = body as Player;
            p1.progress = level;
            GD.Print("Level: " + p1.progress);
            
        }
    }
}
