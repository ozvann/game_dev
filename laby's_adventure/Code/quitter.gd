extends Button



func _ready() -> void:
	var button = Button.new()
	button.text = "QUITTER"
	button.pressed.connect(self._button_pressed)
	add_child(button)


func _button_pressed() -> void:
	get_tree().quit();
