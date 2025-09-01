extends CharacterBody3D

@export var speed = 5.0
@export var jump_force = 10.0
@export var gravity = 40.0
@export var mouse_sensitivity = 0.2
@onready var stamina = 1000
@onready var camera_pivot = $CameraPivot
@onready var camera = $CameraPivot/Camera3D
@onready var light = $SpotLight3D




func _ready():
	Input.set_mouse_mode(Input.MOUSE_MODE_CAPTURED)


func _unhandled_input(event):
	if event is InputEventMouseMotion:
		rotate_y(-event.relative.x * mouse_sensitivity * 0.01)
		camera_pivot.rotate_x(-event.relative.y * mouse_sensitivity * 0.01)
		camera_pivot.rotation_degrees.x = clamp(camera_pivot.rotation_degrees.x, -60, 60)


func _physics_process(delta: float) -> void:
	var direction = Vector3.ZERO
	if Input.is_action_pressed("move_forward"):
		direction.z += 1
	if Input.is_action_pressed("move_backward"):
		direction.z -= 1
	if Input.is_action_pressed("move_left"):
		direction.x -= 1
	if Input.is_action_pressed("move_right"):
		direction.x += 1
	direction = direction.normalized()


	var basis = global_transform.basis
	var forward = -basis.z.normalized()
	var right = basis.x.normalized()
	var move = (forward * direction.z + right * direction.x).normalized()

	if Input.is_action_pressed("run") and stamina > 0:
		velocity.x = move.x * speed * 2
		velocity.z = move.z * speed * 2
		stamina -= 3
	else:
		velocity.x = move.x * speed
		velocity.z = move.z * speed
		if stamina < 1000:
			stamina += 1


	if not is_on_floor():
		velocity.y -= gravity * delta


	if Input.is_action_just_pressed("jump") and is_on_floor():
		velocity.y = jump_force


	move_and_slide()
