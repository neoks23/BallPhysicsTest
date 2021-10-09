using Godot;
using System;

public class MovingPlatform : CSGBox
{
    [Export]
    float maxX = 10.0f;
    [Export]
    float minX = -10.0f;
    [Export]
    float maxY = 10.0f;
    [Export]
    float minY = -10.0f;
    [Export]
    float maxZ = 10.0f;
    [Export]
    float minZ = -10.0f;
    [Export]
    float moveSpeed = 0.5f;
    [Export]
    bool dir = false;
    [Export]
    int mode = 0;
    /*
    mode as in X = 0, Y = 1, Z = 2, XY = 3, YZ = 4, XZ = 5;
    
    in three bit:

    X | Y | Z
    1 | 0 | 0 = 0 X
    0 | 1 | 0 = 1 Y
    0 | 0 | 1 = 2 Z
    1 | 1 | 0 = 3 XY
    0 | 1 | 1 = 4 YZ
    1 | 0 | 1 = 5 XZ

    */

    public override void _Process(float delta)
    {

        switch (mode)
        {
            case 0:
                if (Translation.x < minX)
                {
                    dir = false;
                }
                if (Translation.x > maxX)
                {
                    dir = true;
                }
                break;
            case 1:
                if (Translation.y < minY)
                {
                    dir = false;
                }
                if (Translation.y > maxY)
                {
                    dir = true;
                }
                break;
            case 2:
                if (Translation.z < minZ)
                {
                    dir = false;
                }
                if (Translation.z > maxZ)
                {
                    dir = true;
                }
                break;
        }
        switch (mode)
        {
            case 0:
                if (dir)
                {
                    Translation -= new Vector3(moveSpeed, 0, 0);
                }
                else
                {
                    Translation += new Vector3(moveSpeed, 0, 0);
                }
                break;
            case 1:
                if (dir)
                {
                    Translation -= new Vector3(0, moveSpeed, 0);
                }
                else
                {
                    Translation += new Vector3(0, moveSpeed, 0);
                }

                break;
            case 2:
                if (dir)
                {
                    Translation -= new Vector3(0, 0, moveSpeed);
                }
                else
                {
                    Translation += new Vector3(0, 0, moveSpeed);
                }
                
                break;
        }
    }

}
