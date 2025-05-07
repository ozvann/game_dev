extends CharacterBody2D

const SPEED = 300.0

func _physics_process(_delta):
	var directionY = Input.get_axis("haut", "bas")
	
	if Input.is_action_just_pressed("gauche"):
		velocity.x = SPEED * -1
		$Sprite2D.flip_h = false
	if Input.is_action_just_released("gauche"):
		velocity.x = 0
	if Input.is_action_just_pressed("droite"):
		$Sprite2D.flip_h = true
		velocity.x = SPEED
	if Input.is_action_just_released("droite"):
		velocity.x = 0
	if directionY:
		velocity.y = directionY * SPEED
	else:
		velocity.y = move_toward(velocity.y, 0, SPEED)
	
	move_and_slide()
	
