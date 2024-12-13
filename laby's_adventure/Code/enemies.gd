extends Sprite2D



func _ready() -> void:
	pass 



func _on_area_2d_body_entered(_body: Node2D) -> void:
	visible = false
	


func _on_area_2d_body_exited(_body: Node2D) -> void:
	visible = true
