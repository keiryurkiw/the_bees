using Godot;

public partial class Bee : RigidBody2D
{
	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
