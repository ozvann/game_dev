extends CharacterBody2D


const SPEED = 300.0
const JUMP_VELOCITY = -400.0


func _physics_process(delta: float) -> void:
	if not is_on_floor():
		velocity += (get_gravity() * delta)
		$AnimationPlayer.play("chute")
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = JUMP_VELOCITY
	var direction := Input.get_axis("ui_left", "ui_right")
	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()


func annimation():
	if Input.is_action_just_pressed("ui_right"):
		$AnimationPlayer.play("marche")
		$Bucheron.flip_h = false
		$Bras.flip_h = false
	if Input.is_action_just_pressed("ui_left"):
		$AnimationPlayer.play("marche")
		$Bucheron.flip_h = true
		$Bras.flip_h = true
	if Input.is_action_just_released("ui_right") or Input.is_action_just_released("ui_left"):
		$AnimationPlayer.play("idle")
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		$AnimationPlayer.play("saut")
