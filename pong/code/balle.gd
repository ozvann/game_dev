extends CharacterBody2D


const SPEED = 150
const GRAV = 190


var col = 0
var mur = 0



func _physics_process(delta):
	
	if is_on_ceiling():
		col += 1
	if is_on_floor():
		col -= 1
	
	if col:
		velocity.y = GRAV
	else:
		velocity.y = -GRAV
	
	
	if is_on_wall():
		mur += 1
	if is_on_wall():
		mur -= 1
	
	if mur:
		velocity.x = SPEED
	else:
		velocity.x = -SPEED

	move_and_slide()