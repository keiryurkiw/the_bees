using Godot;

public partial class Bee : Node2D
{
	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
