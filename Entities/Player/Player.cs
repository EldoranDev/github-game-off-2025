using System.ComponentModel;
using System.Diagnostics;
using System.Transactions;
using Godot;

namespace HyperActive.Entities.Player
{

	public partial class Player : Entity
	{
		private Camera3D camera;

		[Export(PropertyHint.Layers3DPhysics)]
		public uint RotationMask;

		private Vector3 _targetVelocity = Vector3.Zero;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			base._Ready();
			
			camera = GetViewport().GetCamera3D();
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

        public override void _PhysicsProcess(double delta)
        {
			var direction = Vector3.Zero;

			if (Input.IsActionPressed("move_left"))
			{
				direction.X += 1.0f;
			}

			if (Input.IsActionPressed("move_right"))
			{
				direction.X -= 1.0f;
			}


			if (Input.IsActionPressed("move_up"))
			{
				direction.Z += 1.0f;
			}

			if (Input.IsActionPressed("move_down"))
			{
				direction.Z -= 1.0f;
			}

			if (direction != Vector3.Zero)
			{
				direction = direction.Normalized();
			}

			_targetVelocity.X = direction.X * Stats.Speed;
			_targetVelocity.Z = direction.Z * Stats.Speed;

			Velocity = _targetVelocity;
			MoveAndSlide();

			UpdateRotation();
        }

		
		private void UpdateRotation()
		{
			var mouse = GetViewport().GetMousePosition();

			var rayOrigin = camera.ProjectRayOrigin(mouse);
			var rayDirection = rayOrigin + camera.ProjectRayNormal(mouse) * 100;
			var rayQuery = PhysicsRayQueryParameters3D.Create(rayOrigin, rayDirection, RotationMask);
			rayQuery.CollideWithBodies = true;
			rayQuery.CollideWithBodies = true;

			var space = camera.GetWorld3D().DirectSpaceState;

			var collision = space.IntersectRay(rayQuery);

			if (collision.ContainsKey("position"))
            {
            	LookAt(collision["position"].AsVector3() + new Vector3(0, 1, 0), Vector3.Up);    
            }
        }
	}
}
