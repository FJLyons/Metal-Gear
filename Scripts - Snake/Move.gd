extends KinematicBody2D

var timeElapsed = 0
var moveSpeed = 256

func _ready():
	set_process(true)

func _process(delta):
	timeElapsed = timeElapsed + delta
	
	_movement(delta)
	
	if(timeElapsed >= 0.1):
		timeElapsed = 0

func _movement(delta):
	#action presses defined in project settings -> input map (in header)
	#putting action presses into function would allow diagonal movement / removed elses
	
	if(Input.is_action_pressed("Move Down")):
		_move_down(delta)
	
	else: if(Input.is_action_pressed("Move Up")):
		_move_up(delta)
	
	else: if(Input.is_action_pressed("Move Left")):
		_move_left(delta)
	
	else: if(Input.is_action_pressed("Move Right")):
		_move_right(delta)
	

func _move_down(delta):
	var pos = Vector2(0, 0)
	pos.y = moveSpeed * delta
	move_and_collide(pos)

func _move_up(delta):
	var pos = Vector2(0, 0)
	pos.y = -moveSpeed * delta
	move_and_collide(pos)

func _move_left(delta):
	var pos = Vector2(0, 0)
	pos.x = -moveSpeed * delta
	move_and_collide(pos)

func _move_right(delta):
	var pos = Vector2(0, 0)
	pos.x = moveSpeed * delta
	move_and_collide(pos)

