extends Node3D


func _on_jouer_button_pressed() -> void:
	get_tree().change_scene_to_file("res://scene/game.tscn")


func _on_quitter_button_pressed() -> void:
	get_tree().quit()


func _on_continuer_button_pressed() -> void:
	pass # A voir comment géré les sauvegarde
