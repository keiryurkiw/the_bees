using Godot;

public partial class main : Node2D
{
	[Export]
	public PackedScene beeScene { get; set; }

	private int score = 0;

	private void onBeeTimerTimout()
	{
		Bee bee = beeScene.Instantiate<Bee>();

		PathFollow2D beeSpawnLocation = GetNode<PathFollow2D>("BeePath/BeeSpawnPath");
		beeSpawnLocation.ProgressRatio = GD.Randf();

		float direction = beeSpawnLocation.Rotation + Mathf.Pi * 2.0f;
		bee.Position = beeSpawnLocation.Position;
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		bee.Rotation = direction;

		Vector2 velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		bee.LinearVelocity = velocity.Rotated(direction);

		AddChild(bee);
	}
}
