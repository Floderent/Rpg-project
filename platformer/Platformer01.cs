using Godot;
using System;

public partial class Platformer01 : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//================================================
		if (Input.IsActionPressed("change_level"))
		{
			ChangeLevel();
		}
		//================================================
	}

	private void ChangeLevel()
	{
		//PackedScene simultaneousScene = ((PackedScene)ResourceLoader.Load("res://main_scene.tscn"));
		//GetTree().ChangeSceneToPacked(simultaneousScene);
	}

}
