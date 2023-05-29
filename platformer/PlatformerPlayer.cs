using Godot;
using System;

public partial class PlatformerPlayer : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public Area2D ActionnableFinder;


    public override void _Ready()
    {     
        ActionnableFinder = GetNode<Area2D>("Direction/ActionnableFinder");
    }
    public override void _Process(double delta)
	{
		ChangeAnimation();
		CollectObject();
	}

	private void CollectObject()
	{
        var actionnables = ActionnableFinder.GetOverlappingAreas();
        if (actionnables.Count > 0)
        {
			foreach(Area2D actionnableArea in actionnables)
			{
				var actionnable = (Actionnable)actionnableArea;
				actionnable.Action();
			}            
        }
    }
	
	private void ChangeAnimation() {
		
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
		if (Velocity.X > 0)
		{
			animatedSprite2D.FlipH = false;
		}
		else if (Velocity.X < 0)
		{
			animatedSprite2D.FlipH = true;
		}
		
		if(Velocity.Y < 0)
		{
			animatedSprite2D.Animation = "jump";
		} 
		else 
		{
			if(Velocity.X != 0)
			{
				animatedSprite2D.Animation = "walk";
			} else 
			{
				animatedSprite2D.Animation = "idle";
			}
		}
		animatedSprite2D.Play();
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
