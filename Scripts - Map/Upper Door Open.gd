extends Area2D

onready var snake = get_tree().get_nodes_in_group("Player")[0]
onready var snakeLower = snake.get_node("Lower Body")

onready var black = self.get_node("Black")
var blackScale = 0
var blackFinalScale = 0

var firstTouch = true
var freezePos = Vector2(0, 0)

func _ready():
	blackFinalScale = black.scale.x
	black.scale.x = 0
	black.set_offset(Vector2(12, 0))
	
	set_process(true)

func _process(delta):
	if(overlaps_area(snakeLower)):
		if(firstTouch):
			freezePos = snake.position
			firstTouch = false
		
		pull_door(delta)
		hold_snake(freezePos)

func pull_door(delta):
	black.position.x = 68
	
	for i in range(0, 100):
		if(blackScale < blackFinalScale):
			blackScale += delta / 20
			if(blackScale > blackFinalScale):
				blackScale = blackFinalScale
			black.scale.x = blackScale
		black.position.x -= 1

func hold_snake(freezePos):
	if(blackScale < blackFinalScale):
		snake.position = freezePos