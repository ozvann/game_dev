extends Node2D



func _ready() -> void:
	visible = false


func _process(_delta: float) -> void:
	if visible == false and Input.is_action_just_pressed("ui_cancel"):
		visible = true
	else:
		if visible == true and Input.is_action_just_pressed("ui_cancel"):
			get_tree().paused = false
			visible = false
	if visible == true:
		get_tree().paused = true


func _on_continuer_pressed() -> void:
	get_tree().paused = false
	visible = false
