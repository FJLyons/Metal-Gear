extends Area2D

onready var snake = get_tree().get_nodes_in_group("Player")[0]
onready var camera = get_tree().get_nodes_in_group("Camera")[0]
onready var doors = get_tree().get_nodes_in_group("UpperDoors")
onready var screens = get_tree().get_nodes_in_group("Screen")

onready var snakeLower = snake.get_node("Lower Body")

onready var currentRoom = get_parent()
onready var desiredScreen = get_parent()
onready var desiredRoom = get_parent()
onready var roomNo = "1"

func _ready():
	set_process(true)
	find_screen()
	find_door()

func _process(delta):
	if(overlaps_area(snakeLower)):
			close_door()
			teleport()

func find_screen():
	for screen in screens:
		print(self.name + " and " + screen.name)
		if(self.name == screen.name):
			desiredScreen = screen
			break

func find_door():
	for door in doors:
		print(currentRoom.name + " and " + desiredScreen.name + " - " + door.name)
		if(currentRoom.name == desiredScreen.name + " - " + door.name):
			roomNo = door.name
			desiredRoom = door.get_parent()
			break

func close_door():
	var door = desiredRoom.get_node(roomNo);
	var black = door.get_node("Black")
	black.position.x = desiredRoom.position.x
	black.scale.x = door.blackFinalScale
	door.firstTouch = true
	door.blackScale = 0

func teleport():
	print(desiredRoom.name)
	
	camera.position = desiredScreen.position
	snake.position = Vector2(desiredRoom.position.x - 192, desiredRoom.position.y + 32)
		
	print(camera.position)