extends CharacterBody2D

const SPEED = 300.0

func _physics_process(_delta):
	var directionY = Input.get_axis("ui_up", "ui_down")
	
	if Input.is_action_just_pressed("ui_left"):
		velocity.x = SPEED * -1
		$Sprite2D.flip_h = false
	if Input.is_action_just_released("ui_left"):
		velocity.x = 0
	if Input.is_action_just_pressed("ui_right"):
		$Sprite2D.flip_h = true
		velocity.x = SPEED
	if Input.is_action_just_released("ui_right"):
		velocity.x = 0
	if directionY:
		velocity.y = directionY * SPEED
	else:
		velocity.y = move_toward(velocity.y, 0, SPEED)
	
	move_and_slide()
	
