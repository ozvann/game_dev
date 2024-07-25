extends Button



func _ready():
	var button = Button.new()
	button.text = "Jouer en mode histoir"
	button.pressed.connect(self._button_pressed)
	add_child(button)

func _button_pressed():
	get_tree().change_scene_to_file("res://scene/histoir.tscn");
