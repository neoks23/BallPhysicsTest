using Godot;
using System;

public class lblLevel : Label
{
    Player p1;
    public override void _Ready()
    {
        p1 = GetNode("../../Player/PlayerRB") as Player;
    }

    public override void _Process(float delta)
    {
        Text = "    Level    " + p1.progress.ToString();
    }
}
