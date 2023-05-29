using Godot;
using System;

public partial class Platformer01 : Node2D
{
	[Signal]
	public delegate void GoToPlainEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GoToPlain += () =>
		{
			PackedScene simultaneousScene = ((PackedScene)ResourceLoader.Load("res://levels/house_map/house_map_scene.tscn"));
			GetTree().ChangeSceneToPacked(simultaneousScene);
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}


}
