using Godot;

public partial class Actionnable : Area2D
{	
	[Export]	
	public Resource DialogueResource;	
	[Export]
	public string DialogueStart = "start";

	public void Action()
	{		
		PackedScene balloonScene = ((PackedScene)ResourceLoader.Load("res://helpers/balloon.tscn"));
		Node balloonNode = balloonScene.Instantiate();		
		AddChild(balloonNode);
		balloonNode.Call("start", DialogueResource, DialogueStart);		
	}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
