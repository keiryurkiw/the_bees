using Godot;

public partial class main : Node2D
{
	[Export]
	public PackedScene beeScene { get; set; }

	private int score = 0;

	public void newGame()
	{
		score = 0;

		Player player = GetNode<Player>("Player");
		Marker2D startPosition = GetNode<Marker2D>("StartPosition");
		player.Start(startPosition.Position);

		GetNode<Godot.Timer>("StartTimer").Start();
	}

	public void endGame()
	{
		GetNode<Godot.Timer>("BeeTimer").Stop();
		GetNode<Godot.Timer>("ScoreTimer").Stop();
	}

	public void OnScoreTimerTimeout()
	{
		++score;
	}

	public void OnStartTimerTimeout()
	{
		GetNode<Godot.Timer>("BeeTimer").Start();
		GetNode<Godot.Timer>("ScoreTimer").Start();
	}

	public void OnBeeTimerTimeout()
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

	public override void _Ready()
	{
		newGame();
	}
}
