using Godot;

public partial class main : Node2D
{
	[Export]
	public PackedScene beeScene { get; set; }

	private int score = 0;
}
