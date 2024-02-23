using Godot;

public partial class Bee : Node2D
{
	private const string beeScenePath = "res://bee.tscn";
	private PackedScene beeScene = null;
	private Node bee = null;

	public override void _Ready()
	{
		base._Ready();
		beeScene = GD.Load<PackedScene>(beeScenePath);
	}

	public void createBee()
	{
		bee = beeScene.Instantiate();
		AddChild(bee);
	}

	public void destroyBee()
	{
			RemoveChild(bee);
	}
}
