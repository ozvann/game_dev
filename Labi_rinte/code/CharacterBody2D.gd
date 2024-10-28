extends CharacterBody2D



const SPEED = 300.0



func _physics_process(delta):
	var directionX = Input.get_axis("ui_left", "ui_right")
	var directionY = Input.get_axis("ui_up", "ui_down")
	
	if directionX:
		velocity.x = directionX * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
	
	if directionY:
		velocity.y = directionY * SPEED
	else:
		velocity.y = move_toward(velocity.y, 0, SPEED)
	
	
	animation()
	move_and_slide()
	



func animation():
	if Input.is_action_pressed("ui_up"):
		$AnimationPlayer.play("run")
	if Input.is_action_just_released("ui_up"):
		$AnimationPlayer.play("idle")
	
	if Input.is_action_pressed("ui_down"):
		$AnimationPlayer.play("run")
	if Input.is_action_just_released("ui_down"):
		$AnimationPlayer.play("idle")
		
	if Input.is_action_pressed("ui_right"):
		$AnimationPlayer.play("run")
	if Input.is_action_just_released("ui_right"):
		$AnimationPlayer.play("idle")
	
	if Input.is_action_pressed("ui_left"):
		$AnimationPlayer.play("run")
	if Input.is_action_just_released("ui_left"):
		$AnimationPlayer.play("idle")
	if Input.is_action_just_pressed("ui_left"):
		$Sprite2D.flip_h = true

	if Input.is_action_just_pressed("ui_right"):
		$Sprite2D.flip_h = false
