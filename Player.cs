using Godot;
using System;

public partial class Player : CharacterBody2D
{	
	[Export]
	public int Speed = 1;
	[Export]
	public int CurrentHp = 10;
	[Export]
	public int MaxHp = 10;
	
	public Vector2 ScreenSize;
	public Area2D ActionnableFinder;

	
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		ActionnableFinder = GetNode<Area2D>("Direction/ActionnableFinder");
	}

	public override async void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);

		if (Input.IsActionPressed("ui_accept"))
		{
			var actionnables = ActionnableFinder.GetOverlappingAreas();
			if(actionnables.Count > 0)
			{
				((Actionnable)actionnables[0]).Action();				
				return;
			}
		}				

	}

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		
		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}

		/*
		var newPosition = velocity;
		newPosition = new Vector2(
			x: Mathf.Clamp(newPosition.X, 0, ScreenSize.X),
			y: Mathf.Clamp(newPosition.Y, 0, ScreenSize.Y)
		);
		*/
		this.MoveAndCollide(velocity);
		
		
		if (velocity.X != 0)
		{
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.FlipV = false;
			// See the note below about boolean assignment.
			animatedSprite2D.FlipH = velocity.X < 0;
		}
		else if (velocity.Y != 0)
		{
			if(velocity.Y > 0) {
				animatedSprite2D.Animation = "down";
			} else {
				animatedSprite2D.Animation = "up";
			}
		}
	}
}
