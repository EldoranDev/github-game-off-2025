using Godot;
using System;
using System.Reflection.Metadata.Ecma335;

namespace HyperActive.Entities.Player
{

	public partial class Player : CharacterBody3D
	{
		private Camera3D camera;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			camera = GetViewport().GetCamera3D();
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			UpdateRotation();
		}
		
		private void UpdateRotation()
		{
			// TODO: Improve this and refactor where its done
			var mouse = GetViewport().GetMousePosition();

			var rayOrigin = camera.ProjectRayOrigin(mouse);
			var rayDirection = rayOrigin + camera.ProjectRayNormal(mouse) * 100;
			var rayQuery = PhysicsRayQueryParameters3D.Create(rayOrigin, rayDirection, 0xFFFFFF);
			rayQuery.CollideWithBodies = true;
			rayQuery.CollideWithBodies = true;

			var space = camera.GetWorld3D().DirectSpaceState;

			var collision = space.IntersectRay(rayQuery);

			LookAt(collision["position"].AsVector3(), Vector3.Up);
        }
	}
}
