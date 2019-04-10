extends Area2D

onready var snake = get_tree().get_nodes_in_group("Player")[0]
onready var camera = get_tree().get_nodes_in_group("Camera")[0]
onready var rooms = get_tree().get_nodes_in_group("UpperRooms")

onready var snakeLower = snake.get_node("Lower Body")

onready var desiredRoom = get_parent().get_node(self.name)

func _ready():
	set_process(true)
	find_room()

func _process(delta):
	if(overlaps_area(snakeLower)):
			teleport()

func find_room():
	for room in rooms:
		print(self.name + " and " + room.name)
		if(self.name == room.name):
			desiredRoom = room
			break

func teleport():
	print(desiredRoom.name)
	
	camera.position = desiredRoom.position
	snake.position = Vector2(camera.position.x - 64, camera.position.y + 300)
	
	print(camera.position)