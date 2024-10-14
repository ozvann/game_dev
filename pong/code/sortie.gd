extends Sprite2D


func _on_porte_body_exited(body):
	get_tree().change_scene_to_file("res://scene/jeu.tscn")
