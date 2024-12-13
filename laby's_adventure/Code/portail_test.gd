extends Sprite2D


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.



func _on_zone_test_area_body_entered(body: Node2D) -> void:
	get_tree().change_scene_to_file("res://Scene/zone_test.tscn")
