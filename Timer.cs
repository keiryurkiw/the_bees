using Godot;
using System;

public partial class Timer : Node
{
    RichTextLabel timerText = null;
    RichTextLabel pointsText = null;
    Godot.Timer timer = null;

    int points = 0;
    double time = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        timerText = GetNode<RichTextLabel>("/root/Main/Timer/TimerText");
        pointsText = GetNode<RichTextLabel>("/root/Main/Timer/PointsText");

        timer = GetNode<Godot.Timer>("/root/Main/Timer");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        time += delta;
        timerText.Text = TimeSpan.FromSeconds(time).ToString(@"d\d\,\ hh\:mm\:ss");
        points = (int)time / 6;
        pointsText.Text = "[right]" + points + " points[/right]";
    }
}
