extends Sprite2D


func _on_porte_body_entered(body):
	get_tree().change_scene_to_file("res://scene/credit.tscn");
