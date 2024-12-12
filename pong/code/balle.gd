extends CharacterBody2D


<<<<<<< HEAD
const SPEED = 250
const GRAV = 200
=======
const SPEED = 300
const GRAV = 300
>>>>>>> 5a4dec92a6d6393154d4e5cfb73a124c067cca3e


var col = 0
var mur = 0
var ver = 0



func _physics_process(delta):
	
	
	
	
	if is_on_ceiling():
		col += 1
		ver += 1
	if is_on_floor():
		col -= 1
		ver += 1
	
	if col:
		velocity.y = GRAV
	else:
		velocity.y = -GRAV
	
	
	
	
	if is_on_wall() and ver >= 1:
		if mur == 1:
			mur = 0
		else:
			mur = 1
		ver = 0
	
	if mur:
		velocity.x = SPEED
	else:
		velocity.x = -SPEED

	move_and_slide()
