extends Button



func _ready():
	var button = Button.new()
	button.text = "QUITTER"
	button.pressed.connect(self._button_pressed)
	add_child(button)

func _button_pressed():
	get_tree().quit();
