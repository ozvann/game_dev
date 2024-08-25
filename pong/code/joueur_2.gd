extends CharacterBody2D


const SPEED = 400.0


func _physics_process(delta):


	var direction = Input.get_axis("ui_up2", "ui_down2")
	if direction:
		velocity.y = direction * SPEED
	else:
		velocity.y = move_toward(velocity.y, 0, SPEED)

	move_and_slide()
