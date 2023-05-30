using Godot;
using System;

public partial class HouseMapScene : Node2D
{
	[Signal]
	public delegate void GoToDevHouseEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GoToDevHouse += () =>
		{
			PackedScene simultaneousScene = ((PackedScene)ResourceLoader.Load("res://platformer/platformer_01.tscn"));
			GetTree().ChangeSceneToPacked(simultaneousScene);			
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
