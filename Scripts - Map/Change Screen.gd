extends Area2D

onready var snake = get_tree().get_nodes_in_group("Player")[0]
onready var camera = get_tree().get_nodes_in_group("Camera")[0]
onready var screen = get_tree().get_nodes_in_group("Screen")[0]

onready var screenWidth = 1024
onready var screenHeight = 768

onready var snakeHor = screenWidth / 2 - 64
onready var snakeVert = screenHeight / 2 - 96

onready var snakeLower = snake.get_node("Lower Body")

func _ready():
	set_process(true)

func _process(delta):
	if(overlaps_area(snakeLower)):
		if(self.is_in_group("North Wall")):
			teleport("North")
			
		else: if(self.is_in_group("South Wall")):
			teleport("South")
			
		else: if(self.is_in_group("East Wall")):
			teleport("East")
			
		else: if(self.is_in_group("West Wall")):
			teleport("West")

func teleport(direction):
	print(direction)
	
	if(direction == "North"):
		camera.position.y -= screenHeight
		snake.position.y = camera.position.y + snakeVert
		
	else: if(direction == "South"):
		camera.position.y += screenHeight
		snake.position.y = camera.position.y - snakeVert
		
		if(self.is_in_group("Opening Wall")):
			snake.position.y = camera.position.y - snakeVert
		
	else: if(direction == "East"):
		camera.position.x += screenWidth
		snake.position.x = camera.position.x - snakeHor
		
	else: if(direction == "West"):
		camera.position.x -= screenWidth
		snake.position.x = camera.position.x + snakeHor
	
	print(camera.position)