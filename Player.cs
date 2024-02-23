using Godot;

public partial class Player : Area2D
{
    [Export]
    public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).

    public Vector2 ScreenSize; // Size of the game window.

    public override void _Ready()
    {
        Hide();
        base._Ready();
        ScreenSize = GetViewportRect().Size;

    }

    public void OnHit()
    {
        Hide(); // Player disappears after being hit.
        EmitSignal("Hit");
        // Must be deferred as we can't change physics properties on a physics callback.
        GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
    }

    public void Start(Vector2 position)
    {
        Position = position;
        Show();
        GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
    }

    public override void _Process(double delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("right"))
        {
            velocity.X += 1;
        }

        if (Input.IsActionPressed("left"))
        {
            velocity.X -= 1;
        }

        if (Input.IsActionPressed("down"))
        {
            velocity.Y += 1;
        }

        if (Input.IsActionPressed("up"))
        {
            velocity.Y -= 1;
        }


        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }
        Position += velocity * (float)delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
            y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
        );
    }
}
