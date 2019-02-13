extends AnimatedSprite

var timeElapsed = 0

var timeFrame = 0
var frameSpeed = 0.2

var standFrame = 0
var startFrame = 1
var endFrame = 2

func _ready():
	set_process(true)

func _process(delta):
	timeElapsed = timeElapsed + delta
	timeFrame = timeFrame + delta
	
	_animate(delta)
	
	if(timeElapsed >= 0.10):
		timeElapsed = 0

func _animate(delta):
	#action presses defined in project settings -> input map (in header)
	
	if(Input.is_action_pressed("Move Down")):
		_unarmed("unarmed_down")
	
	else: if(Input.is_action_pressed("Move Up")):
		_unarmed("unarmed_up")
	
	else: if(Input.is_action_pressed("Move Left")):
		_unarmed("unarmed_left")
		
	else: if(Input.is_action_pressed("Move Right")):
		_unarmed("unarmed_right")
	
	if(Input.is_action_just_released("Move Down") || Input.is_action_just_released("Move Up")
	|| Input.is_action_just_released("Move Left") || Input.is_action_just_released("Move Right")):
		set_frame(standFrame)
		stop()
	

func _unarmed(anime):	
	if(timeFrame >= frameSpeed):
			set_animation(anime)
			if(get_frame() == get_sprite_frames().get_frame_count(get_animation()) - 1):
				set_frame(startFrame)
			else:
				set_frame(get_frame() + 1)
			timeFrame = 0