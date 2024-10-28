extends Node2D



func _ready() -> void:
	visible = false


func _process(delta: float) -> void:
	if visible == false and Input.is_action_just_pressed("ui_cancel"):
		visible = true
	else:
		if visible == true and Input.is_action_just_pressed("ui_cancel"):
			visible = false


func _on_continuer_pressed() -> void:
	visible = false
